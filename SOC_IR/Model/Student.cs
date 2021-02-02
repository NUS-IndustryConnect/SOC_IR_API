using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOC_IR.Model
{
    [Table("IDC_STD", Schema = "OWNIDC")]
    public class Student
    {
        [Key]
        [Column("NUSNET_ID")]
        private string studentId { get; set; }
        [Column("STD_NM")]
        private string name { get; set; }
        [Column("LAST_LOGIN_DTM")]
        private string lastLoggedIn { get; set; }
    }
}
