using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class GetCompanyAdminDto
    {
        private string companyId { get; set; }
        private string companyName { get; set; }
        private string companyTier { get; set; }
        private string companyDescription { get; set; }
        private Boolean isActive { get; set; }

        public GetCompanyAdminDto (string companyId, string companyName, string companyTier, string companyDescription, Boolean isActive)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
            this.isActive = isActive;
        }
}
}
