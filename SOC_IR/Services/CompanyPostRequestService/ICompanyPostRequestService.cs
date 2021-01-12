using SOC_IR.Dtos.CompanyPostRequest;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyPostRequestService
{
    public interface ICompanyPostRequestService
    {
        public Task<ServiceResponse<List<GetCompanyPostRequestDto>>> GetCompanyPostRequests();
        public Task<ServiceResponse<List<GetCompanyPostRequestDto>>> GetCompanyPostRequestsByCompany(string id);
        public Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ApproveCompanyPost(ApproveCompanyPostRequestDto toApprove);
        public Task<ServiceResponse<List<GetCompanyPostRequestDto>>> CreateCompanyPostRequest(CreateCompanyPostRequestDto toCreate);
        public Task<ServiceResponse<List<GetCompanyPostRequestDto>>> RejectCompanyPost(RejectCompanyPostRequestDto toReject);
    }
}
