using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    public class Student
    {
        private string studentID { get; set; }
        private string name { get; set; }
        private string lastLoggedIn { get; set; }
        private List<string> announcementIdList { get; set; }
        private List<string> companyPostIdList { get; set; }
    }
}
