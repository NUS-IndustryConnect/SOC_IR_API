using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyUser
{
    public class CompanyUserDto
    {
        public string companyUserID { get; set; }
        public string companyID { get; set; }
        public string email { get; set; }
        public string lastLoggedIn { get; set; }
        public List<string> companyUserPostIds { get; set; }

        public CompanyUserDto(string companyUserID, string companyID, string email, string lastLoggedIn, List<string> companyUserPostIds)
        {
            this.companyUserID = companyUserID;
            this.companyID = companyID;
            this.email = email;
            this.lastLoggedIn = lastLoggedIn;
            this.companyUserPostIds = companyUserPostIds;
        }
    }
}
