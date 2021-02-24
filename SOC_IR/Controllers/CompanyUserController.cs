using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.CompanyUser;
using SOC_IR.Model;
using SOC_IR.Services.CompanyUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyUserController : ControllerBase
    {
        private readonly ICompanyUserService _companyUserService;

        public CompanyUserController(ICompanyUserService companyService)
        {
            this._companyUserService = companyService;
        }

        [HttpGet("users")]
        async public Task<IActionResult> getAllCompanyUsers()
        {
            ServiceResponse<List<CompanyUserDto>> response = await _companyUserService.GetAllCompanyUsers();
            return Ok(response.Data);
        }

        [HttpGet("company/{companyID}")]
        async public Task<IActionResult> getCompanyUsersFromCompany(string companyId)
        {
            ServiceResponse<List<CompanyUserDto>> response = await _companyUserService.GetCompanyUsersFromCompany(companyId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("user/{companyUserID}")]
        async public Task<IActionResult> getCompanyUserFromId(string companyUserId)
        {
            ServiceResponse<CompanyUserDto> response = await _companyUserService.GetCompanyUserFromId(companyUserId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompanyUser(CreateCompanyUserDto companyUserDto)
        {
            ServiceResponse<CompanyUserDto> response = await _companyUserService.CreateCompanyUser(companyUserDto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{companyUserID}")]
        async public Task<IActionResult> deleteCompanyUser(string companyUserId)
        {
            ServiceResponse<List<CompanyUserDto>> response = await _companyUserService.DeleteCompanyUser(companyUserId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("archive/{id}")]
        async public Task<IActionResult> archiveCompanyPost(string id)
        {
            ServiceResponse<CompanyUserDto> response = await _companyUserService.ArchiveUser(id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("unarchive/{id}")]
        async public Task<IActionResult> unarchiveCompanyPost(string id)
        {
            ServiceResponse<CompanyUserDto> response = await _companyUserService.UnarchiveUser(id);
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
