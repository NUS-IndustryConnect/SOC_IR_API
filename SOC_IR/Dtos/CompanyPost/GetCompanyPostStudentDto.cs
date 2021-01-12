using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class GetCompanyPostStudentDto
    {
        public string companyPostId { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string lastUpdated { get; set; }
        public string validTill { get; set; }

        public GetCompanyPostStudentDto(string companyPostId, string companyId, string companyName, string postTitle, string postSubTitle, 
            string postDescription, string videoUrl, string links, string lastUpdated, string validTill)
        {
            this.companyPostId = companyPostId;
            this.companyId = companyId;
            this.companyName = companyName;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.lastUpdated = lastUpdated;
            this.validTill = validTill;
        }
    }
}
