using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyUser
{
    public class CompanyUserDto
    {
        public string companyUserId { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string lastLoggedIn { get; set; }

        public CompanyUserDto(string companyUserId, string companyId, string companyName, string email, string lastLoggedIn)
        {
            this.companyUserId = companyUserId;
            this.companyId = companyId;
            this.companyName = companyName;
            this.email = email;
            this.lastLoggedIn = lastLoggedIn;
        }
    }
}
