using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class Admin
    {
        [Key]
        public string adminID { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public Admin(string adminID, string name, string email)
        {
            this.adminID = adminID;
            this.name = name;
            this.email = email;
        }
    }
}
