using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    public class Company
    {
        private string companyID { get; set; }
        private string companyName { get; set; }
        private string companyTier { get; set; }
        private List<string> companyPostIdList { get; set; }
    }
}
