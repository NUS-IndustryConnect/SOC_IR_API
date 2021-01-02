using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.CompanyPost;
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
            return Ok(await _companyPostService.GetCompanyPostAdmin());
        }

        [HttpGet("valid")]
        async public Task<IActionResult> getValidCompanyPostAdmin()
        {
            return Ok(await _companyPostService.GetValidCompanyPostAdmin());
        }

        [HttpGet("company/{companyID}")]
        async public Task<IActionResult> getCompanyPostByCompany(string companyID)
        {
            return Ok(await _companyPostService.GetCompanyPostByCompany(companyID));
        }

        [HttpGet("company/{companyID}/valid")]
        async public Task<IActionResult> getValidCompanyPostByCompany(string companyID)
        {
            return Ok(await _companyPostService.GetValidCompanyPostByCompany(companyID));
        }

        [HttpGet("student")]
        async public Task<IActionResult> getCompanyPostStudent()
        {
            return Ok(await _companyPostService.GetCompanyPostStudent());
        }

        [HttpGet("user/{companyUserID}")]
        async public Task<IActionResult> getCompanyPostStudent(string companyUserID)
        {
            return Ok(await _companyPostService.GetCompanyPostUser(companyUserID));
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompanyPost(CreateCompanyPostDto companyPostDto)
        {
            return Ok(await _companyPostService.CreateCompanyPost(companyPostDto));
        }

        [HttpPost("update")]
        async public Task<IActionResult> updateCompanyPost(UpdateCompanyPostDto companyPostDto)
        {
            return Ok(await _companyPostService.UpdateCompanyPost(companyPostDto));
        }

        [HttpDelete("delete")]
        async public Task<IActionResult> deleteCompanyPost(List<string> ids)
        {
            return Ok(await _companyPostService.DeleteCompanyPosts(ids));
        }

        [HttpPost("archive")]
        async public Task<IActionResult> archiveCompanyPost(List<string> ids)
        {
            return Ok(await _companyPostService.ArchiveCompanyPosts(ids));
        }
    }
}
