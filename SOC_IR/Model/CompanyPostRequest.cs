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
        public string companyPostRequestID { get; set; }
        public string companyID { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public List<string> links { get; set; }
        public string validTill { get; set; }
        public string status { get; set; }
        public string feedback { get; set; }

        public CompanyPostRequest(string companyPostRequestID, string companyID, string postTitle, string postSubTitle, string postDescription,
            string videoUrl, List<string> links, string validTill, string status, string feedback)
        {
            this.companyPostRequestID = companyPostRequestID;
            this.companyID = companyID;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.validTill = validTill;
            this.status = status;
            this.feedback = feedback;
        }
    }
}
