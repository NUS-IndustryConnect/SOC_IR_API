using Microsoft.AspNetCore.Mvc;
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

        public CompanyController(ICompanyService companyService)
        {
            this._companyUserService = companyService;
        }

        [HttpGet("admin")]
        async public Task<IActionResult> getCompanyAdmin()
        {
            return Ok(await _companyUserService.GetCompanyAdmin());
        }

        [HttpGet("student")]
        async public Task<IActionResult> getCompanyStudent()
        {
            return Ok(await _companyUserService.GetCompanyStudent());
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompany(CreateCompanyDto companyDto)
        {
            return Ok(await _companyUserService.CreateCompany(companyDto));
        }

        [HttpPost("update")]
        async public Task<IActionResult> createCompany(UpdateCompanyDto companyDto)
        {
            return Ok(await _companyUserService.UpdateCompany(companyDto));
        }

        [HttpDelete("create/{id}")]
        async public Task<IActionResult> deleteCompany(string id)
        {
            return Ok(await _companyUserService.DeleteCompany(id));
        }
    }
}
