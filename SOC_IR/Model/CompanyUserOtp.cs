using SOC_IR.Dtos.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    [Table("IDC_ORGN_USER_LOGIN", Schema = "OWNIDC")]
    public class CompanyUserOtp
    {
        [Column("USER_ID")]
        public string companyUserId { get; set; }
        [Column("LOGIN_DTM")]
        public string logInTime { get; set; }
        [Column("EMADDR_T")]
        public string email { get; set; }
        [Column("OTP")]
        public string otp { get; set; }
        [Column("OTP_ATTEMPT_COUNT")]
        public int otpAttemptCount { get; set; }
        [Column("IS_EXPIRED")]
        public Boolean isExpired { get; set; }

        public CompanyUserOtp(string companyUserId, string logInTime, string email, string otp, int otpAttemptCount, bool isExpired)
        {
            this.companyUserId = companyUserId;
            this.logInTime = logInTime;
            this.email = email;
            this.otp = otp;
            this.otpAttemptCount = otpAttemptCount;
            this.isExpired = isExpired;
        }
    }
}
