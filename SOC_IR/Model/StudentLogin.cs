using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    [Table("IDC_STD_USER_LOGIN", Schema = "OWNIDC")]
    public class StudentLogin
    {
        [Column("NUSNET_ID")]
        public string nusnetId { get; set; }
        [Column("LOGIN_DTM")]
        public string logInTime { get; set; }

        public StudentLogin(string nusnetId, string logInTime)
        {
            this.nusnetId = nusnetId;
            this.logInTime = logInTime;
        }
    }
}
