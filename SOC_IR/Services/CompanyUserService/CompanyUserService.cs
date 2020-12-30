using SOC_IR.Dtos.CompanyUser;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyUserService
{
    public class CompanyUserService : ICompanyUserService
    {
        Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.CreateCompanyUser(CreateCompanyUserDto companyUserDto)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.DeleteCompanyUser(string companyUserID)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.GetAllCompanyUsers()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.GetCompanyUserFromId(string companyUserID)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.GetCompanyUsersFromCompany(string companyID)
        {
            throw new NotImplementedException();
        }
    }
}
