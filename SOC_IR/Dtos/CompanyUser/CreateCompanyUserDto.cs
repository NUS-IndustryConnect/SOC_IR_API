using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyUser
{
    public class CreateCompanyUserDto
    {
        public string companyId { get; set; }
        public string email { get; set; }
        public CreateCompanyUserDto(string companyId, string email)
        {
            this.companyId = companyId;
            this.email = email;
        }
    }
}
