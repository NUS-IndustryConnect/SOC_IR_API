using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class CompanyPostRequest
    {
    

        [Key]
        public string companyPostRequestId { get; set; }
        public string companyId { get; set; }
        public string companyUserId { get; set; }
        public string companyName { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string validTill { get; set; }
        public string status { get; set; }
        public string feedback { get; set; }

        public CompanyPostRequest(string companyPostRequestId, string companyId, string companyUserId, string companyName, string postTitle, string postSubTitle, 
            string postDescription, string videoUrl, string links, string validTill, string status, string feedback)
        {
            this.companyPostRequestId = companyPostRequestId;
            this.companyId = companyId;
            this.companyUserId = companyUserId;
            this.companyName = companyName;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.validTill = validTill;
            this.status = status;
            this.feedback = feedback;
        }

        public void companyUpdated(string companyName)
        {
            this.companyName = companyName;
        }
    }
}
