using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.CompanyPostRequest;
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
            return Ok(await _companyPostRequestService.GetCompanyPostRequests());
        }

        [HttpGet("{companyID}")]
        async public Task<IActionResult> getRequestsByCompany(string companyID)
        {
            return Ok(await _companyPostRequestService.GetCompanyPostRequestsByCompany(companyID));
        }

        [HttpPost("create")]
        async public Task<IActionResult> createRequest(CreateCompanyPostRequestDto dto)
        {
            return Ok(await _companyPostRequestService.CreateCompanyPostRequest(dto));
        }

        [HttpPost("approve")]
        async public Task<IActionResult> createRequest(ApproveCompanyPostRequestDto dto)
        {
            return Ok(await _companyPostRequestService.ApproveCompanyPost(dto));
        }

        [HttpPost("reject")]
        async public Task<IActionResult> createRequest(RejectCompanyPostRequestDto dto)
        {
            return Ok(await _companyPostRequestService.RejectCompanyPost(dto));
        }
    }

}
