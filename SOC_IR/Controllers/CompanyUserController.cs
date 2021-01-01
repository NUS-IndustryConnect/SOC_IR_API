using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.CompanyUser;
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
            return Ok(await _companyUserService.GetAllCompanyUsers());
        }

        [HttpGet("company/{companyID}")]
        async public Task<IActionResult> getCompanyUsersFromCompany(string companyID)
        {
            return Ok(await _companyUserService.GetCompanyUsersFromCompany(companyID));
        }

        [HttpGet("user/{companyUserID}")]
        async public Task<IActionResult> createCompanyUser(string companyUserID)
        {
            return Ok(await _companyUserService.GetCompanyUserFromId(companyUserID));
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompanyUser(CreateCompanyUserDto companyUserDto)
        {
            return Ok(await _companyUserService.CreateCompanyUser(companyUserDto));
        }

        [HttpDelete("{companyUserID}")]
        async public Task<IActionResult> deleteCompany(string companyUserID)
        {
            return Ok(await _companyUserService.DeleteCompanyUser(companyUserID));
        }
    }
}
