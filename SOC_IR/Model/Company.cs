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
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string companyTier { get; set; }
        public string companyDescription { get; set; }

        public Company(string companyId, string companyName, string companyTier, string companyDescription)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
        }
    }
}
