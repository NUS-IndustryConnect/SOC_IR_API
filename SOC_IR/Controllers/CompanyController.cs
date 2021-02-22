using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.Company;
using SOC_IR.Model;
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
            _companyService = companyService;
        }

        [HttpGet("admin")]
        async public Task<IActionResult> getCompanyAdmin()
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = await _companyService.GetCompanyAdmin();
            return Ok(response.Data);
        }

        [HttpGet("student")]
        async public Task<IActionResult> getCompanyStudent()
        {
            ServiceResponse<List<GetCompanyStudentDto>> response = await _companyService.GetCompanyStudent();
            return Ok(response.Data);
        }

        [HttpPost("create")]
        async public Task<IActionResult> createCompany(CreateCompanyDto companyDto)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = await _companyService.CreateCompany(companyDto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
           
        }

        [HttpPut("update/{companyId}")]
        async public Task<IActionResult> updateCompany(string companyId, UpdateCompanyDto updatedCompanyDto)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = await _companyService.UpdateCompany(companyId, updatedCompanyDto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpDelete("{companyID}")]
        async public Task<IActionResult> deleteCompany(string companyID)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = await _companyService.DeleteCompany(companyID);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("archive/{companyID}")]
        async public Task<IActionResult> archiveCompany(string companyID)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = await _companyService.ArchiveCompany(companyID);
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
