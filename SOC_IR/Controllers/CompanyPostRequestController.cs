using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.CompanyPost;
using SOC_IR.Dtos.CompanyPostRequest;
using SOC_IR.Model;
using SOC_IR.Services.CompanyPostRequestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyPostRequestController : ControllerBase
    {
        private readonly ICompanyPostRequestService _companyPostRequestService;

        public CompanyPostRequestController(ICompanyPostRequestService companyService)
        {
            this._companyPostRequestService = companyService;
        }

        [HttpGet("")]
        async public Task<IActionResult> getAllRequests()
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = await _companyPostRequestService.GetCompanyPostRequests();
            return Ok(response.Data);
        }

        [HttpGet("{companyID}")]
        async public Task<IActionResult> getRequestsByCompany(string companyId)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = await _companyPostRequestService.GetCompanyPostRequestsByCompany(companyId);
            return Ok(response.Data);
        }

        [HttpPost("create")]
        async public Task<IActionResult> createRequest(CreateCompanyPostRequestDto dto)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = await _companyPostRequestService.CreateCompanyPostRequest(dto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
            
        }

        [HttpPut("approve")]
        async public Task<IActionResult> createRequest(ApproveCompanyPostRequestDto dto)
        {
            ServiceResponse<List<GetCompanyPostAdminDto>> response = await _companyPostRequestService.ApproveCompanyPost(dto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPut("reject")]
        async public Task<IActionResult> createRequest(RejectCompanyPostRequestDto dto)
        {
            ServiceResponse<List<GetCompanyPostRequestDto>> response = await _companyPostRequestService.RejectCompanyPost(dto);
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
