using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class CreateCompanyPostDto
    {
        public string companyID { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public List<string> links { get; set; }
        public string approvedBy { get; set; }
        public string validTill { get; set; }

        public CreateCompanyPostDto(string companyID, string postTitle, string postSubTitle, string postDescription, 
            string videoUrl, List<string> links, string approvedBy, string validTill)
        {
            this.companyID = companyID;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.approvedBy = approvedBy;
            this.validTill = validTill;
        }
    }
}
