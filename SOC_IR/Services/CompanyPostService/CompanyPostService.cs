using SOC_IR.Dtos.CompanyPost;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyPostService
{
    public class CompanyPostService : ICompanyPostService
    {
        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.ArchiveCompanyPosts(List<string> postIds)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.CreateCompanyPost(CreateCompanyPostDto companyPostDto)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.DeleteCompanyPosts(List<string> postIds)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostAdmin()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostByCompany(string id)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostStudentDto>>> ICompanyPostService.GetCompanyPostStudent()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostUser(string id)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> ICompanyPostService.GetValidCompanyPostAdmin()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> ICompanyPostService.GetValidCompanyPostByCompany(string id)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.UpdateCompanyPost(CreateCompanyPostDto companyPostDto)
        {
            throw new NotImplementedException();
        }
    }
}
