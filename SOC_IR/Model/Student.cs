using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class Student
    {
        [Key]
        private string studentID { get; set; }
        private string name { get; set; }
        private string lastLoggedIn { get; set; }
        private List<string> announcementIdList { get; set; }
        private List<string> companyPostIdList { get; set; }
    }
}
