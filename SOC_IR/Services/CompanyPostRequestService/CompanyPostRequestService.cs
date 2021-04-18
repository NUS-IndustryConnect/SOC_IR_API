using Microsoft.EntityFrameworkCore;
using SOC_IR.Data;
using SOC_IR.Dtos.CompanyPost;
using SOC_IR.Dtos.CompanyPostRequest;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
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

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostRequestService.ApproveCompanyPost(ApproveCompanyPostRequestDto toApprove)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            CompanyPostRequest req = await _context.CompanyPostRequests.FirstOrDefaultAsync(a => toApprove.companyPostRequestId == a.companyPostRequestId);
            Admin admin = await _context.Admins.FirstOrDefaultAsync(a => toApprove.approvedby == a.nusNetId);

            if (req == null)
            {
                response.Success = false;
                response.Message = "This request does not exist";
                return response;
            }
            string companyName = _context.Companies.FirstAsync(a => a.companyId == req.companyId).Result.companyName;
            string approvedBy = toApprove.approvedby;
            CompanyPost post = new CompanyPost(req.companyUserId, new ApprovalDto(req, companyName, approvedBy));
            _context.CompanyPostRequests.Remove(req);
            await _context.CompanyPosts.AddAsync(post);
            await _context.SaveChangesAsync();

            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.CreateCompanyPostRequest(CreateCompanyPostRequestDto toCreate)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            Company comp = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == toCreate.companyId);
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.companyUserId == toCreate.companyUserId);
            if (comp == null)
            {
                response.Success = false;
                response.Message = "The company approving the request does not exist";
                return response;
            }
            if (user == null)
            {
                response.Success = false;
                response.Message = "The company user creating this does not exist";
                return response;
            }


            string finalString = new IDGenerator.IDGenerator().generate();
            string lastUpdated = new DateTime().ToString();
            CompanyPostRequest req = new CompanyPostRequest(finalString, toCreate.companyId, toCreate.companyUserId, comp.companyName, toCreate.postTitle,
                toCreate.postSubTitle, toCreate.postDescription, toCreate.videoUrl, toCreate.links, toCreate.validTill, "pending", null);
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
            List<GetCompanyPostRequestDto> data = await _context.CompanyPostRequests.Where(a=>a.companyId == id).Select(a => new GetCompanyPostRequestDto(a)).ToListAsync();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostRequestDto>>> ICompanyPostRequestService.RejectCompanyPost(RejectCompanyPostRequestDto toReject)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = new ServiceResponse<List<GetCompanyPostRequestDto>>();
            CompanyPostRequest request = await _context.CompanyPostRequests.FirstOrDefaultAsync(a => a.companyPostRequestId == toReject.companyPostRequestId);

            if (request == null)
            {
                response.Success = false;
                response.Message = "This request does not exist";
                return response;
            }

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
