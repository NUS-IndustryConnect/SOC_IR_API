using Microsoft.AspNetCore.Mvc;
using SOC_IR.Services.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        [HttpGet("")]
        async public Task<IActionResult> getAllAdmin()
        {
            return Ok(await _adminService.GetAllAdmin());
        }

        [HttpGet("{nusNetId}")]
        async public Task<IActionResult> getAdminById(string nusNetId)
        {
            return Ok(await _adminService.GetAdminById(nusNetId));
        }
    }
}
