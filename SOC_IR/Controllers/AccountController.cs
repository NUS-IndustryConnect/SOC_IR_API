using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SOC_IR.Data;
using SOC_IR.Dtos.Account;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("login/soc")]
        async public Task<IActionResult> LoginSoc()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "INC000002302194");

            var uri = "https://luminus.azure-api.net/login/ADFSToken?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

            string apiResponse = await response.Content.ReadAsStringAsync();
            LoginStudentDto data = JsonConvert.DeserializeObject<LoginStudentDto>(apiResponse);
            return Ok(data);
        }

        

        [HttpPost("login/company")]
        public async Task<IActionResult> LoginCompany(LoginCompanyEmailDto loginDto)
        {
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.email == loginDto.email);
            if(user == null)
            {
                return NotFound("The user does not exist");
            }

            string otp = "Your One time password is 123456";
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("pandher.ekam@gmail.com", "Ek@m1234567"),
                EnableSsl = true,
                Timeout = 20000
            };

            smtpClient.Send("pandher.ekam@gmail.com", loginDto.email, "One Time Password", otp);
            return Ok("You have been sent an email with your otp");
        }

        [HttpPost("login/company/otp")]
        public async Task<IActionResult> LoginCompanyOtp(LoginCompanyOtpDto loginDto)
        {
            if(loginDto.otp == "123456")
            {
                CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.email == loginDto.email);
                return Ok(user);
            }
            else
            {
                return BadRequest("Error wrong OTP entered");
            }
        }


    }
}
