using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class Company
    {
        [Key]
        public string companyID { get; set; }
        public string companyName { get; set; }
        public string companyTier { get; set; }
        public string companyDescription { get; set; }
        public List<string> companyPostIdList { get; set; }

        public Company(string companyID, string companyName, string companyTier, string companyDescription, List<string> companyPostIdList)
        {
            this.companyID = companyID;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
            this.companyPostIdList = companyPostIdList;
        }
    }
}
