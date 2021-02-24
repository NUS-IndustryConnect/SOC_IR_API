using Microsoft.EntityFrameworkCore;
using SOC_IR.Data;
using SOC_IR.Dtos.CompanyPost;
using SOC_IR.Model;
using SOC_IR.Services.IDGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyPostService
{
    public class CompanyPostService : ICompanyPostService
    {
        private readonly DataContext _context;
        public CompanyPostService(DataContext context)
        {
            _context = context;
        }
        async Task<ServiceResponse<GetCompanyPostAdminDto>> ICompanyPostService.ArchiveCompanyPost(string postId)
        {
            ServiceResponse<GetCompanyPostAdminDto> response = new ServiceResponse<GetCompanyPostAdminDto>();
            CompanyPost post = await _context.CompanyPosts.FirstOrDefaultAsync(async => async.companyPostId == postId);
            if (post == null)
            {
                response.Success = false;
                response.Message = "The post you wish to archive does not exist";
                return response;
            }
            post.archivePost();
            _context.CompanyPosts.Update(post);
            await _context.SaveChangesAsync();
            GetCompanyPostAdminDto companyPostAdminDto = new GetCompanyPostAdminDto(post.companyPostId, post.companyUserId, post.companyId, post.companyName, post.postTitle, post.postSubTitle, post.postDescription, post.videoUrl, post.links, post.lastUpdated, post.approvedBy, post.validTill, post.isActive);
            response.Data = companyPostAdminDto;
            return response;
            
        }

        async Task<ServiceResponse<GetCompanyPostAdminDto>> ICompanyPostService.UnarchiveCompanyPost(string postId)
        {
            ServiceResponse<GetCompanyPostAdminDto> response = new ServiceResponse<GetCompanyPostAdminDto>();
            CompanyPost post = await _context.CompanyPosts.FirstOrDefaultAsync(async => async.companyPostId == postId);
            if (post == null)
            {
                response.Success = false;
                response.Message = "The post you wish to archive does not exist";
                return response;
            }
            post.unarchivePost();
            _context.CompanyPosts.Update(post);
            await _context.SaveChangesAsync();
            GetCompanyPostAdminDto companyPostAdminDto = new GetCompanyPostAdminDto(post.companyPostId, post.companyUserId, post.companyId, post.companyName, post.postTitle, post.postSubTitle, post.postDescription, post.videoUrl, post.links, post.lastUpdated, post.approvedBy, post.validTill, post.isActive);
            response.Data = companyPostAdminDto;
            return response;

        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.CreateCompanyPost(CreateCompanyPostDto companyPostDto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            Company companyOfPost = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == companyPostDto.companyId);
            CompanyUser companyUserOfPost = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.companyUserId == companyPostDto.companyUserId);
            if (companyOfPost == null)
            {
                response.Success = false;
                response.Message = "The company for this post does not exist";
                return response;
            }
            if (companyUserOfPost == null)
            {
                response.Success = false;
                response.Message = "The poster of the post does not exist";
                return response;
            }

            
            string finalString = new IDGenerator.IDGenerator().generate();
            string lastUpdated = DateTime.Now.ToString();
            CompanyPost newPost = new CompanyPost(finalString, companyPostDto.companyId, companyPostDto.companyUserId, companyOfPost.companyName, companyPostDto.postTitle, companyPostDto.postSubTitle, companyPostDto.postDescription, companyPostDto.videoUrl, companyPostDto.links, lastUpdated, companyPostDto.approvedBy, companyPostDto.validTill, true);
            await _context.CompanyPosts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.DeleteCompanyPost(string postId)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            CompanyPost deletedPost = await _context.CompanyPosts.FirstOrDefaultAsync(async => async.companyPostId == postId);
            if (deletedPost == null)
            {
                response.Success = false;
                response.Message = "The post you want to delete does not exist";
                return response;
            }
            _context.CompanyPosts.RemoveRange(deletedPost);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostAdmin()
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostByCompany(string id)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            Company comp = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == id);
            if(comp == null)
            {
                response.Success = false;
                response.Message = "The company you requested does not exist";
                return response;
            }
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Where(a=>a.companyId == id).Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostStudentDto>>> ICompanyPostService.GetCompanyPostStudent()
        {
            ServiceResponse<List<GetCompanyPostStudentDto>> response = new ServiceResponse<List<GetCompanyPostStudentDto>>();
            List<GetCompanyPostStudentDto> postList = await _context.CompanyPosts.Where(a => a.isActive).Select(a => new GetCompanyPostStudentDto(a.companyPostId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.validTill)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostByUser(string id)
        {
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.companyUserId == id);
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            if (user == null)
            {
                response.Success = false;
                response.Message = "The company user you requested does not exist";
                return response;
            }
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Where(a => a.companyUserId == id).Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> ICompanyPostService.GetValidCompanyPostAdmin()
        {
            ServiceResponse<List<GetCompanyPostAdminValidDto>> response = new ServiceResponse<List<GetCompanyPostAdminValidDto>>();
            List<GetCompanyPostAdminValidDto> postList = await _context.CompanyPosts.Where(a => a.isActive).Select(a => new GetCompanyPostAdminValidDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> ICompanyPostService.GetValidCompanyPostByCompany(string id)
        {
            ServiceResponse<List<GetCompanyPostAdminValidDto>> response = new ServiceResponse<List<GetCompanyPostAdminValidDto>>();
            Company comp = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == id);
            if (comp == null)
            {
                response.Success = false;
                response.Message = "The company you requested does not exist";
                return response;
            }
            List<GetCompanyPostAdminValidDto> postList = await _context.CompanyPosts.Where(a => a.isActive && a.companyId == id).Select(a => new GetCompanyPostAdminValidDto(a.companyPostId, a.companyId, a.companyUserId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.UpdateCompanyPost(UpdateCompanyPostDto companyPostDto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            CompanyPost post = await _context.CompanyPosts.FirstOrDefaultAsync(a => a.companyPostId == companyPostDto.companyPostId);
            if (post == null)
            {
                response.Success = false;
                response.Message = "The post you want to update not exist";
                return response;
            }
            post.update(companyPostDto);
            _context.CompanyPosts.Update(post);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostId, a.companyUserId, a.companyId, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;

        }
    }
}
