using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class CreateCompanyDto
    {
        public string companyName { get; set; }
        public string companyTier { get; set; }
        public string companyDescription { get; set; }
    }
}
