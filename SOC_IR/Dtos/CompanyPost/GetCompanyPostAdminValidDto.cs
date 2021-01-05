using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class GetCompanyPostAdminValidDto
    {
        public string companyPostID { get; set; }
        public string companyID { get; set; }
        public string companyName { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public List<string> links { get; set; }
        public string lastUpdated { get; set; }
        public string approvedBy { get; set; }
        public string validTill { get; set; }

        public GetCompanyPostAdminValidDto(string companyPostID, string companyID, string companyName, string postTitle, string postSubTitle, string postDescription, 
            string videoUrl, List<string> links, string lastUpdated, string approvedBy, string validTill)
        {
            this.companyPostID = companyPostID;
            this.companyID = companyID;
            this.companyName = companyName;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.lastUpdated = lastUpdated;
            this.approvedBy = approvedBy;
            this.validTill = validTill;
        }
    }
}
