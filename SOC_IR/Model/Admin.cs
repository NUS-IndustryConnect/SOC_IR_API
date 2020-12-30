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
        private string adminID { get; set; }
        private string name { get; set; }
        private string email { get; set; }

    }
}
