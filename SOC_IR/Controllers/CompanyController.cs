using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.Company;
using SOC_IR.Services.CompanyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }

        [HttpGet("admin")]
        async public Task<IActionResult> getCompanyAdmin()
        {
            return Ok(await _companyService.GetCompanyAdmin());
        }

        [HttpGet("student")]
        async public Task<IActionResult> getCompanyStudent()
        {
            return Ok(await _companyService.GetCompanyStudent());
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompany(CreateCompanyDto companyDto)
        {
            return Ok(await _companyService.CreateCompany(companyDto));
        }

        [HttpPost("update")]
        async public Task<IActionResult> createCompany(UpdateCompanyDto companyDto)
        {
            return Ok(await _companyService.UpdateCompany(companyDto));
        }

        [HttpDelete("{companyID}")]
        async public Task<IActionResult> deleteCompany(string companyID)
        {
            return Ok(await _companyService.DeleteCompany(companyID));
        }

        [HttpPost("archive/{companyID}")]
        async public Task<IActionResult> archiveCompany(string companyID)
        {
            return Ok(await _companyService.ArchiveCompany(companyID));
        }
    }
}
