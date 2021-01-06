using SOC_IR.Dtos.CompanyPost;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyPostService
{
    public interface ICompanyPostService
    {
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> GetCompanyPostAdmin();
        public Task<ServiceResponse<List<GetCompanyPostStudentDto>>> GetCompanyPostStudent();
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> GetCompanyPostUser(string id);
        public Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> GetValidCompanyPostAdmin();
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> GetCompanyPostByCompany(string id);
        public Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> GetValidCompanyPostByCompany(string id);
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> CreateCompanyPost(CreateCompanyPostDto companyPostDto);
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> UpdateCompanyPost(UpdateCompanyPostDto companyPostDto);
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ArchiveCompanyPosts(List<string> postIds);
        public Task<ServiceResponse<List<GetCompanyPostAdminDto>>> DeleteCompanyPosts(List<string> postIds);

    }
}
