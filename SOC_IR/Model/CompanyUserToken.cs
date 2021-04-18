using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    [Table("IDC_ORGN_USER_TOKEN", Schema = "OWNIDC")]
    public class CompanyUserToken
    {
        [Key]
        [Column("USER_ID")]
        public string companyUserId { get; set; }
        [Column("LOGIN_DTM")]
        public string logInTime { get; set; }
        [Column("TOKEN")]
        public string token { get; set; }

        public CompanyUserToken(string companyUserId, string logInTime, string token)
        {
            this.companyUserId = companyUserId;
            this.logInTime = logInTime;
            this.token = token;
        }
    }
}
