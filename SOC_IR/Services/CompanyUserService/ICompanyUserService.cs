using SOC_IR.Dtos.CompanyUser;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyUserService
{
    public interface ICompanyUserService
    {
        public Task<ServiceResponse<List<CompanyUserDto>>> GetAllCompanyUsers();
        public Task<ServiceResponse<List<CompanyUserDto>>> GetCompanyUsersFromCompany(string companyID);
        public Task<ServiceResponse<CompanyUserDto>> GetCompanyUserFromId(string companyUserID);
        public Task<ServiceResponse<CompanyUserDto>> CreateCompanyUser(CreateCompanyUserDto updatedCompanyDto);
        public Task<ServiceResponse<List<CompanyUserDto>>> DeleteCompanyUser(string companyUserID);
    }
}
