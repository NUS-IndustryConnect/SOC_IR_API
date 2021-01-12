using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class UpdateCompanyPostDto
    {
        public string companyPostId { get; set; }
        public string companyUserId { get; set; }
        public string companyId { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string approvedBy { get; set; }
        public string validTill { get; set; }

        public UpdateCompanyPostDto(string companyPostId, string companyUserId, string companyId, string postTitle, string postSubTitle, 
            string postDescription, string videoUrl, string links, string approvedBy, string validTill)
        {
            this.companyPostId = companyPostId;
            this.companyUserId = companyUserId;
            this.companyId = companyId;
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
