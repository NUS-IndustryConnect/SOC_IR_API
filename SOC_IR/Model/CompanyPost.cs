using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class CompanyPost
    {
        [Key]
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
        public Boolean isActive { get; set; }

        public CompanyPost(string companyPostID, string companyID, string companyName, string postTitle, string postSubTitle, string postDescription,
            string videoUrl, List<string> links, string lastUpdated, string approvedBy, string validTill, bool isActive)
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
            this.isActive = isActive;
        }

        public void archivePost()
        {
            this.isActive = false;
        }

        public void companyUpdated(string companyName)
        {
            this.companyName = companyName;
        }
    }
}
