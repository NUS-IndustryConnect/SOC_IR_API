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
        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.ArchiveCompanyPosts(List<string> postIds)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            List<CompanyPost> posts = _context.CompanyPosts.ToList().Where(a => postIds.Contains(a.companyPostID)).ToList();
            posts.ForEach(a => a.archivePost());
            _context.CompanyPosts.UpdateRange(posts);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a=> new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
            
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.CreateCompanyPost(CreateCompanyPostDto companyPostDto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            Company companyOfPost = await _context.Companies.FirstAsync(a => a.companyID == companyPostDto.companyID);
            CompanyUser companyUserOfPost = await _context.CompanyUsers.FirstAsync(a => a.companyUserID == companyPostDto.approvedBy);
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
            string lastUpdated = new DateTime().ToString();
            CompanyPost newPost = new CompanyPost(finalString, companyPostDto.companyID, companyOfPost.companyName, companyPostDto.postTitle, companyPostDto.postSubTitle, companyPostDto.postDescription, companyPostDto.videoUrl, new List<string>(), lastUpdated, companyPostDto.approvedBy, companyPostDto.validTill, true);
            companyOfPost.addPost(finalString);
            companyUserOfPost.addPost(finalString);
            _context.Companies.Update(companyOfPost);
            _context.CompanyUsers.Update(companyUserOfPost);
            await _context.CompanyPosts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.DeleteCompanyPosts(List<string> postIds)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            List<CompanyPost> deletedPosts = await _context.CompanyPosts.Where(a => postIds.Contains(a.companyPostID)).ToListAsync();
            await _context.Companies.ForEachAsync(a => a.deletePosts(postIds));
            await _context.CompanyUsers.ForEachAsync(a => a.deletePosts(postIds));
            _context.CompanyPosts.RemoveRange(deletedPosts);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostAdmin()
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostByCompany(string id)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Where(a=>a.companyID == id).Select(a => new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostStudentDto>>> ICompanyPostService.GetCompanyPostStudent()
        {
            ServiceResponse<List<GetCompanyPostStudentDto>> response = new ServiceResponse<List<GetCompanyPostStudentDto>>();
            List<GetCompanyPostStudentDto> postList = await _context.CompanyPosts.Where(a => a.isActive).Select(a => new GetCompanyPostStudentDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.validTill)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.GetCompanyPostUser(string id)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            CompanyUser user = await _context.CompanyUsers.FirstAsync(a => a.companyUserID == id);
            List<string> postIdList = user.companyUserPostIds;
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Where(a => postIdList.Contains(a.companyPostID)).Select(a => new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> ICompanyPostService.GetValidCompanyPostAdmin()
        {
            ServiceResponse<List<GetCompanyPostAdminValidDto>> response = new ServiceResponse<List<GetCompanyPostAdminValidDto>>();
            List<GetCompanyPostAdminValidDto> postList = await _context.CompanyPosts.Where(a => a.isActive).Select(a => new GetCompanyPostAdminValidDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminValidDto>>> ICompanyPostService.GetValidCompanyPostByCompany(string id)
        {
            ServiceResponse<List<GetCompanyPostAdminValidDto>> response = new ServiceResponse<List<GetCompanyPostAdminValidDto>>();
            List<GetCompanyPostAdminValidDto> postList = await _context.CompanyPosts.Where(a => a.isActive && a.companyID == id).Select(a => new GetCompanyPostAdminValidDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill)).ToListAsync();
            response.Data = postList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyPostAdminDto>>> ICompanyPostService.UpdateCompanyPost(UpdateCompanyPostDto companyPostDto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = new ServiceResponse<List<GetCompanyPostAdminDto>>();
            CompanyPost post = await _context.CompanyPosts.FirstAsync(a => a.companyPostID == companyPostDto.companyPostId);
            CompanyPost updated = new CompanyPost(post.companyPostID, post.companyID, post.companyName, companyPostDto.postTitle, companyPostDto.postSubTitle, companyPostDto.postDescription, companyPostDto.videoUrl, companyPostDto.links, new DateTime().ToString(), companyPostDto.approvedBy, companyPostDto.validTill, post.isActive);
            _context.CompanyPosts.Update(updated);
            await _context.SaveChangesAsync();
            List<GetCompanyPostAdminDto> postList = await _context.CompanyPosts.Select(a => new GetCompanyPostAdminDto(a.companyPostID, a.companyID, a.companyName, a.postTitle, a.postSubTitle, a.postDescription, a.videoUrl, a.links, a.lastUpdated, a.approvedBy, a.validTill, a.isActive)).ToListAsync();
            response.Data = postList;
            return response;

        }
    }
}
