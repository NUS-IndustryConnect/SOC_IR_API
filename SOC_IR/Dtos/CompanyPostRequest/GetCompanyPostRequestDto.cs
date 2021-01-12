using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPostRequest
{
    public class GetCompanyPostRequestDto
    {
        public string companyPostRequestId { get; set; }
        public string companyUserId { get; set; }
        public string companyId { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string validTill { get; set; }
        public string status { get; set; }
        public string feedback { get; set; }

        public GetCompanyPostRequestDto(string companyPostRequestId, string companyUserId, string companyId, string postTitle, string postSubTitle, 
            string postDescription, string videoUrl, string links, string validTill, string status, string feedback)
        {
            this.companyPostRequestId = companyPostRequestId;
            this.companyUserId = companyUserId;
            this.companyId = companyId;
            this.postTitle = postTitle;
            this.postSubTitle = postSubTitle;
            this.postDescription = postDescription;
            this.videoUrl = videoUrl;
            this.links = links;
            this.validTill = validTill;
            this.status = status;
            this.feedback = feedback;
        }

        public GetCompanyPostRequestDto(SOC_IR.Model.CompanyPostRequest req)
        {
            this.companyPostRequestId = req.companyPostRequestId;
            this.companyUserId = req.companyUserId;
            this.companyId = req.companyId;
            this.postTitle = req.postTitle;
            this.postSubTitle = req.postSubTitle;
            this.postDescription = req.postDescription;
            this.videoUrl = req.videoUrl;
            this.links = req.links;
            this.validTill = req.validTill;
            this.status = req.status;
            this.feedback = req.feedback;
        }
    }
}
