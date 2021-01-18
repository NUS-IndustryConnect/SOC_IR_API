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
        public string adminId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public Admin(string adminId, string name, string email)
        {
            this.adminId = adminId;
            this.name = name;
            this.email = email;
        }
    }
}
