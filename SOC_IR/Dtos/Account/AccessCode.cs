using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Account
{
    public class AccessCode
    {
        public string clientId { get; set; }
        public string code { get; set; }
        public string provider { get; set; }
        public string redirectUri { get; set; }
    }
}
