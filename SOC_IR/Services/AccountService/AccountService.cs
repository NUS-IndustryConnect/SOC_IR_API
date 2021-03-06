﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SOC_IR.Data;
using SOC_IR.Dtos.Account;
using SOC_IR.Model;
using SOC_IR.Services.IdGenerator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOC_IR.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        private readonly IHttpClientFactory _clientFactory;
        public AccountService(DataContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;

        }
        async Task<ServiceResponse<string>> IAccountService.LoginCompany(LoginCompanyEmailDto loginDto)
        {
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.email == loginDto.email);
            ServiceResponse<string> response = new ServiceResponse<string>();
            
            if (user == null)
            {
                response.Success = false;
                response.Message = "The user does not exist";
                return response;
            }
            
            CompanyUserOtp otp = await _context.CompanyUserOtps.FirstOrDefaultAsync(a => a.email == loginDto.email);
            string otpCode = new OtpGenerator().generate();
            if (otp == null)
            {
                otp = new CompanyUserOtp(user.companyUserId, DateTime.Now.ToString(), user.email, otpCode, 0, false);
                await _context.CompanyUserOtps.AddAsync(otp);
            }
            else
            {
                if (DateTime.Now.Subtract(DateTime.Parse(otp.logInTime)).TotalMinutes > 30)
                {
                    otp.isExpired = true;
                }

                if (!otp.isExpired)
                {
                    if (otp.otpAttemptCount > 4)
                    {
                        response.Success = false;
                        response.Message = "The user account is locked";
                        return response;
                    }
                    response.Data = "We have already sent an OTP to your email";
                    return response;
                }
                else
                {
                    if (otp.otpAttemptCount > 4)
                    {
                        response.Success = false;
                        response.Message = "The user account is locked";
                        return response;
                    }
                    else
                    {
                        otp.otp = otpCode;
                        otp.logInTime = DateTime.Now.ToString();
                        otp.otpAttemptCount = 0;
                        _context.CompanyUserOtps.Update(otp);
                    }
                }
            }
            
            var smtpClient = new SmtpClient("mailauth.comp.nus.edu.sg")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("iconnect", "c0nn3ct+c0mpan4"),
                EnableSsl = true,
                Timeout = 20000
            };

            await _context.SaveChangesAsync();
            string message = "Your One Time Password is: " + otpCode;
            smtpClient.Send("iconnect@comp.nus.edu.sg", loginDto.email, "One Time Password", message);
            response.Data = "You have been sent an email with your otp";
            return response;
            
        }

        async Task<ServiceResponse<CompanyUserSuccessDto>> IAccountService.LoginCompanyOtp(LoginCompanyOtpDto loginDto)
        {
            ServiceResponse<CompanyUserSuccessDto> response = new ServiceResponse<CompanyUserSuccessDto>();
       
            CompanyUserOtp otp = await _context.CompanyUserOtps.FirstOrDefaultAsync(a => a.email == loginDto.email);

            if (otp == null)
            {
                response.Success = false;
                response.Message = "Something went wrong, the email sent does not exist";
            }

            if (loginDto.otp == otp.otp)
            {
                CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.email == loginDto.email);
                response.Data = new CompanyUserSuccessDto(user.companyUserId, user.companyId, user.companyName, user.email);
            }
            else if (otp.isExpired || DateTime.Now.Subtract(DateTime.Parse(otp.logInTime)).TotalMinutes > 30)
            {
                otp.isExpired = true;
                _context.CompanyUserOtps.Update(otp);
                response.Success = false;
                response.Message = "The OTP entered has expired";
            }
            else
            {
                otp.otpAttemptCount++;
                _context.CompanyUserOtps.Update(otp);
                response.Success = false;
                response.Message = "Error wrong OTP entered" +otp.otp;
            } 
        
            return response;
        }

        async Task<ServiceResponse<LoginStudentDto>> IAccountService.LoginNusUser(AccessCode code)
        {
            ServiceResponse<LoginStudentDto> response = new ServiceResponse<LoginStudentDto>();
            string uri = "https://vafs.nus.edu.sg/adfs/oauth2/token";
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.Text.Json.JsonSerializer.Serialize(code));
            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(dict))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage returned = await httpClient.PostAsync(uri, content);

                    if (!returned.IsSuccessStatusCode)
                    {
                        var error = returned.Headers.ToString();
                        response.Success = false;
                        response.Message = error;
                        return response;
                    }

                    var returnData = await returned.Content.ReadAsStringAsync();
                    try
                    { 
                        var dataObj = JObject.Parse(returnData);
                        var jwt = $"{dataObj["access_token"]}";
                        var handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(jwt);
                        var claims = token.Payload;
                        LoginStudentDto student = new LoginStudentDto($"{claims["SamAccountName"]}", $"{claims["displayName"]}", "12345678", $"{claims["Windows Domain Name"]}");
                        response.Data = student;
                        return response;
                    }
                    catch (Exception e)
                    {
                        response.Success = false;
                        response.Message = returnData;
                        return response;
                    }

                }
            }
        }
    }
}
