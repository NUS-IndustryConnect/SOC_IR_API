using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class GetCompanyAdminDto
    {
        private string companyID { get; set; }
        private string companyName { get; set; }
        private string companyTier { get; set; }
        private string companyDescription { get; set; }
        private List<string> companyPostIdList { get; set; }

        public GetCompanyAdminDto (string companyID, string companyName, string companyTier, string companyDescription, List<string> companyPostIdList)
        {
            this.companyID = companyID;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
            this.companyPostIdList = companyPostIdList;
        }
}
}
