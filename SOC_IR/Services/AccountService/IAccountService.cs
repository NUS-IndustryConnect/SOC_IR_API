using SOC_IR.Dtos.Account;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.AccountService
{
    public interface IAccountService
    {
        public Task<ServiceResponse<string>> LoginCompany(LoginCompanyEmailDto loginDto);
        public Task<ServiceResponse<CompanyUserSuccessDto>> LoginCompanyOtp(LoginCompanyOtpDto loginDto);
        public Task<ServiceResponse<LoginStudentDto>> LoginNusUser(AccessCode code);
    }
}
