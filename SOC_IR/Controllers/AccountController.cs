using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SOC_IR.Data;
using SOC_IR.Dtos.Account;
using SOC_IR.Model;
using SOC_IR.Services.AccountService;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("login/soc")]
        async public Task<IActionResult> LoginSoc()
        {
            return Ok("");
        }

        

        [HttpPost("login/company")]
        public async Task<IActionResult> LoginCompany(LoginCompanyEmailDto loginDto)
        {
            ServiceResponse<string> response = await _accountService.LoginCompany(loginDto);
            if(!response.Success)
            {
                return NotFound(response.Message);
            }
            else
            {
                return Ok(response.Data);
            }
        }

        [HttpPost("login/company/otp")]
        public async Task<IActionResult> LoginCompanyOtp(LoginCompanyOtpDto loginDto)
        {
            ServiceResponse<CompanyUserSuccessDto> response = await _accountService.LoginCompanyOtp(loginDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            else
            {
                return Ok(response.Data);
            }
        }


    }
}
