using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Account
{
    public class LoginStudentDto
    {
        public string nusnetId { get; set; }
        public string name{ get; set; }
        public string webToken { get; set; }
        public string role { get; set; }
    }
}
