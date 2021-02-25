using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.CompanyPost;
using SOC_IR.Model;
using SOC_IR.Services.CompanyPostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyPostController : ControllerBase
    {
        private readonly ICompanyPostService _companyPostService;

        public CompanyPostController(ICompanyPostService companyService)
        {
            this._companyPostService = companyService;
        }

        [HttpGet("")]
        async public Task<IActionResult> getCompanyPostAdmin()
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostService.GetCompanyPostAdmin();
            return Ok(response.Data);
        }

        [HttpGet("valid")]
        async public Task<IActionResult> getValidCompanyPostAdmin()
        {
            ServiceResponse<List<GetCompanyPostAdminValidDto>> response = await _companyPostService.GetValidCompanyPostAdmin();
            return Ok(response.Data);
        }

        [HttpGet("company/{companyId}")]
        async public Task<IActionResult> getCompanyPostByCompany(string companyId)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostService.GetCompanyPostByCompany(companyId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
            
        }

        [HttpGet("company/{companyId}/valid")]
        async public Task<IActionResult> getValidCompanyPostByCompany(string companyId)
        {
            ServiceResponse<List<GetCompanyPostAdminValidDto>> response = await _companyPostService.GetValidCompanyPostByCompany(companyId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpGet("student")]
        async public Task<IActionResult> getCompanyPostStudent()
        {
            ServiceResponse<List<GetCompanyPostStudentDto>> response = await _companyPostService.GetCompanyPostStudent();
            return Ok(response.Data);
        }

        [HttpGet("user/{companyUserId}")]
        async public Task<IActionResult> getCompanyPostByUser(string companyUserId)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostService.GetCompanyPostByUser(companyUserId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompanyPost(CreateCompanyPostDto companyPostDto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostService.CreateCompanyPost(companyPostDto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("update")]
        async public Task<IActionResult> updateCompanyPost(UpdateCompanyPostDto companyPostDto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostService.UpdateCompanyPost(companyPostDto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpDelete("delete/{postId}")]
        async public Task<IActionResult> deleteCompanyPost(string postId)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostService.DeleteCompanyPost(postId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("archive/{postId}")]
        async public Task<IActionResult> archiveCompanyPost(string postId)
        {
            ServiceResponse<GetCompanyPostAdminDto> response = await _companyPostService.ArchiveCompanyPost(postId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("unarchive/{postId}")]
        async public Task<IActionResult> unarchiveCompanyPost(string postId)
        {
            ServiceResponse<GetCompanyPostAdminDto> response = await _companyPostService.UnarchiveCompanyPost(postId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }
    }
}
