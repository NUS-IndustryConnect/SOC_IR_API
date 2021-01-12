using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class UpdateCompanyDto
    {
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string companyTier { get; set; }
        public string companyDescription { get; set; }

        public UpdateCompanyDto(string companyId, string companyName, string companyTier, string companyDescription)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyDescription = companyDescription;
            this.companyTier = companyTier;
        }
    }
}
