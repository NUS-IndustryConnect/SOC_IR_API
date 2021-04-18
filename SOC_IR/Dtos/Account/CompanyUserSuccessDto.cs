using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Account
{
    public class CompanyUserSuccessDto
    {
        public string companyUserId { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }

        public CompanyUserSuccessDto(string companyUserId, string companyId, string companyName, string email)
        {
            this.companyUserId = companyUserId;
            this.companyId = companyId;
            this.companyName = companyName;
            this.email = email;
        }
    }
}
