using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class GetCompanyPostAdminDto
    {
        public string companyPostId { get; set; }
        public string companyUserId { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string lastUpdated { get; set; }
        public string approvedBy { get; set; }
        public string validTill { get; set; }
        public Boolean isActive { get; set; }

        public GetCompanyPostAdminDto(string companyPostId, string companyUserId, string companyId, string companyName, string postTitle, string postSubTitle, 
            string postDescription, string videoUrl, string links, string lastUpdated, string approvedBy, string validTill, bool isActive)
        {
            this.companyPostId = companyPostId;
            this.companyUserId = companyUserId;
            this.companyId = companyId;
            this.companyName = companyName;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.lastUpdated = lastUpdated;
            this.approvedBy = approvedBy;
            this.validTill = validTill;
            this.isActive = isActive;
        }
    }
}
