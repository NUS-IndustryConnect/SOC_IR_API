using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOC_IR.Model
{
    [Table("IDC_ADMIN", Schema = "OWNIDC")]
    public class Admin
    {
        [Key]
        [Column("NUSNET_ID")]
        public string nusNetId { get; set; }
        [Column("ADMIN_NM")]
        public string name { get; set; }
        [Column("EMADDR_T")]
        public string email { get; set; }

        public Admin(string nusNetId, string name, string email)
        {
            this.nusNetId = nusNetId;
            this.name = name;
            this.email = email;
        }
    }
}
