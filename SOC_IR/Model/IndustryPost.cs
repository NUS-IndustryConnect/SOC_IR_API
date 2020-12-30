using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class IndustryPost
    {
        [Key]
        private string industryPostID { get; set; }
        private string companyID { get; set; }
        private string companyName { get; set; }
        private string postTitle { get; set; }
        private string postSubTitle { get; set; }
        private string postDescription { get; set; }
        private string videoUrl { get; set; }
        private string links { get; set; }
        private string lastUpdated { get; set; }
        private string approvedBy { get; set; }
        private string validTill { get; set; }
        private Boolean isActive { get; set; }


    }
}
