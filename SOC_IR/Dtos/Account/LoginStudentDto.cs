using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Account
{
    public class LoginStudentDto
    {
        string accessToken { get; set; }
        string error { get; set; }
        string refreshToken { get; set; }
        string extras { get; set; }
    }
}
