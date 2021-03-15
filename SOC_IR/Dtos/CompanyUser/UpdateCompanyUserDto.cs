using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyUser
{
    public class UpdateCompanyUserDto
    {
        public string companyUserId { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
    }
}
