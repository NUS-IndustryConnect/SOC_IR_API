using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class GetCompanyAdminDto
    {
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string companyTier { get; set; }
        public string companyDescription { get; set; }
        public bool isActive { get; set; }

        public GetCompanyAdminDto (string companyId, string companyName, string companyTier, string companyDescription, bool isActive)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
            this.isActive = isActive;
        }
}
}
