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
        private string companyUserID { get; set; }
        private string companyID { get; set; }
        private string email { get; set; }
        private string lastLoggedIn { get; set; }
    }
}
