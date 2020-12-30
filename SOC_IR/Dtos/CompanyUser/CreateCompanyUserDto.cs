using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyUser
{
    public class CreateCompanyUserDto
    {
        public string companyID { get; set; }
        public string email { get; set; }
        public CreateCompanyUserDto(string companyID, string email)
        {
            this.companyID = companyID;
            this.email = email;
        }
    }
}
