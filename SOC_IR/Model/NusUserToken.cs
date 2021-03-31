using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    [Table("IDC_NUS_USER_TOKEN", Schema = "OWNIDC")]
    public class NusUserToken
    {
        [Key]
        [Column("NUSNET_ID")]
        public string nusnetId { get; set; }
        [Column("LOGIN_DTM")]
        public string logInTime { get; set; }
        [Column("TOKEN")]
        public string token { get; set; }

        public NusUserToken(string nusnetId, string logInTime, string token)
        {
            this.nusnetId = nusnetId;
            this.logInTime = logInTime;
            this.token = token;
        }
    }
}
