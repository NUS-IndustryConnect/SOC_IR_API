using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOC_IR.Model
{
    [Table("IDC_ORGN", Schema = "OWNIDC")]
    public class Company
    {
        [Key]
        [Column("ORGN_ID")]
        public string companyId { get; set; }
        [Column("ORGN_NM")]
        public string companyName { get; set; }
        [Column("TIER_C")]
        public string companyTier { get; set; }
        [Column("DESC_T")]
        public string companyDescription { get; set; }
        [Column("ACTIVE_F")]
        public Boolean isActive { get; set; }

        public Company(string companyId, string companyName, string companyTier, string companyDescription, Boolean isActive)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
            this.isActive = isActive;
        }
    }
}
