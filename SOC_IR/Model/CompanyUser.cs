using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOC_IR.Model
{
    [Table("IDC_ORGN_USER", Schema = "OWNIDC")]
    public class CompanyUser
    {
        [Key]
        [Column("USER_ID")]
        public string companyUserId { get; set; }
        [Column("ORGN_ID")]
        public string companyId { get; set; }
        [Column("ORGN_NM")]
        public string companyName { get; set; }
        [Column("EMADDR_T")]
        public string email { get; set; }
        [Column("LAST_LOGIN_DTM")]
        public string lastLoggedIn { get; set; }
        [Column("ACTIVE_F")]
        public Boolean isActive { get; set; }

        public CompanyUser(string companyUserId, string companyName, string companyId, string email, string lastLoggedIn, Boolean isActive)
        {
            this.companyUserId = companyUserId;
            this.companyName = companyName;
            this.companyId = companyId;
            this.email = email;
            this.lastLoggedIn = lastLoggedIn;
            this.isActive = isActive;
        }

        public void archiveUser()
        {
            this.isActive = false;
        }

        public void unarchiveUser()
        {
            this.isActive = true;
        }
    }
}
