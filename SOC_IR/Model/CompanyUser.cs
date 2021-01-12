using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class CompanyUser
    {
        [Key]
        public string companyUserId { get; set; }
        public string companyName { get; set; }
        public string companyId { get; set; }
        public string email { get; set; }
        public string lastLoggedIn { get; set; }

        public CompanyUser(string companyUserId, string companyName, string companyId, string email, string lastLoggedIn)
        {
            this.companyUserId = companyUserId;
            this.companyName = companyName;
            this.companyId = companyId;
            this.email = email;
            this.lastLoggedIn = lastLoggedIn;
        }
    }
}
