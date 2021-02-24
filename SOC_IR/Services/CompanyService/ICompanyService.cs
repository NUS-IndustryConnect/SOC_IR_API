using SOC_IR.Dtos.Company;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyService
{
    public interface ICompanyService
    {
        public Task<ServiceResponse<List<Company>>> GetCompany();
        public Task<ServiceResponse<List<GetCompanyAdminDto>>> GetCompanyAdmin();
        public Task<ServiceResponse<List<GetCompanyStudentDto>>> GetCompanyStudent();
        public Task<ServiceResponse<List<GetCompanyAdminDto>>> CreateCompany(CreateCompanyDto companyDto);
        public Task<ServiceResponse<List<GetCompanyAdminDto>>> UpdateCompany(string companyId, UpdateCompanyDto updatedCompanyDto);
        public Task<ServiceResponse<List<GetCompanyAdminDto>>> DeleteCompany(string id);
        public Task<ServiceResponse<List<GetCompanyAdminDto>>> ArchiveCompany(string companyId);
        public Task<ServiceResponse<List<GetCompanyAdminDto>>> UnarchiveCompany(string companyId);
    }
}
