using SOC_IR.Data;
using SOC_IR.Dtos.CompanyPostRequest;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyPostRequestService
{
    public class CompanyPostRequestService : ICompanyPostRequestService
    {
        private readonly DataContext _context;
        public CompanyPostRequestService(DataContext context)
        {
            _context = context;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.ApproveCompanyPosts(ApproveCompanyPostRequestDto toApprove)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            CompanyPostRequest req = await _context.CompanyPostRequests.FirstAsync(a => toApprove.companyPostRequestID == a.companyPostRequestID);
            string companyName = _context.Companies.FirstAsync(a => a.companyID == req.companyID).Result.companyName;
            string approvedBy = toApprove.approvedby;
            CompanyPost post = new CompanyPost ( new ApprovalDto(req, companyName, approvedBy));
            Company comp = await _context.Companies.FirstAsync(a => a.companyID == req.companyID);
            comp.approvePostRequest(req.companyPostRequestID);
            CompanyUser compUser = await _context.CompanyUsers.FirstAsync(a => a.companyUserPostRequestIds.Contains(req.companyPostRequestID));
            compUser.approvePostRequest(req.companyPostRequestID);
            _context.Companies.Update(comp);
            _context.CompanyUsers.Update(compUser);
            _context.CompanyPostRequests.Remove(req);
            await _context.CompanyPosts.AddAsync(post);
            await _context.SaveChangesAsync();
            List<GetCompanyPostRequestDto> data = await _context.CompanyPostRequests.Select(a => new GetCompanyPostRequestDto(a)).ToListAsync();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.CreateCompanyPostRequest(CreateCompanyPostRequestDto toCreate)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            Company comp = await _context.Companies.FirstAsync(a => a.companyID == toCreate.companyID);
            CompanyUser compUser = await _context.CompanyUsers.FirstAsync(a => a.companyUserID == toCreate.companyUserID);
            string finalString = new IDGenerator.IDGenerator().generate();
            string lastUpdated = new DateTime().ToString();
            comp.companyPostRequestIdList.Add(finalString);
            compUser.companyUserPostRequestIds.Add(finalString);
            CompanyPostRequest req = new CompanyPostRequest(finalString, toCreate.companyID, toCreate.postTitle, toCreate.postSubTitle, toCreate.postDescription, toCreate.videoUrl, toCreate.links, toCreate.validTill, "pending", null);
            _context.Companies.Update(comp);
            _context.CompanyUsers.Update(compUser);
            _context.CompanyPostRequests.Add(req);
            await _context.SaveChangesAsync();
            List<GetCompanyPostRequestDto> data = await _context.CompanyPostRequests.Select(a => new GetCompanyPostRequestDto(a)).ToListAsync();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.GetCompanyPostRequests()
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            List<GetCompanyPostRequestDto> data = await _context.CompanyPostRequests.Select(a => new GetCompanyPostRequestDto(a)).ToListAsync();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.GetCompanyPostRequestsByCompany(string id)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            List<GetCompanyPostRequestDto> data = await _context.CompanyPostRequests.Where(a=>a.companyID == id).Select(a => new GetCompanyPostRequestDto(a)).ToListAsync();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.RejectCompanyPosts(RejectCompanyPostRequestDto toReject)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            CompanyPostRequest request = await _context.CompanyPostRequests.FirstAsync(a => a.companyPostRequestID == toReject.companyPostRequestID);
            request.feedback = toReject.feedback;
            request.status = "rejected";
            _context.CompanyPostRequests.Update(request);
            await _context.SaveChangesAsync();
            List<GetCompanyPostRequestDto> data = await _context.CompanyPostRequests.Select(a => new GetCompanyPostRequestDto(a)).ToListAsync();
            response.Data = data;
            return response;
        }
    }
}
