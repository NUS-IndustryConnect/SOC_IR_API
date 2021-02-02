using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOC_IR.Model
{
    [Table("IDC_POST_REQ", Schema = "OWNIDC")]
    public class CompanyPostRequest
    {
        [Key]
        [Column("POST_REQ_ID")]
        public string companyPostRequestId { get; set; }
        [Column("ORGN_ID")]
        public string companyId { get; set; }
        [Column("USER_ID")]
        public string companyUserId { get; set; }
        [Column("ORGN_NM")]
        public string companyName { get; set; }
        [Column("TITLE_T")]
        public string postTitle { get; set; }
        [Column("SUBTITLE_T")]
        public string postSubTitle { get; set; }
        [Column("DESC_T")]
        public string postDescription { get; set; }
        [Column("VIDEO_URL_T")]
        public string videoUrl { get; set; }
        [Column("LINK_T")]
        public string links { get; set; }
        [Column("EXP_D")]
        public string validTill { get; set; }
        [Column("STATUS_T")]
        public string status { get; set; }
        [Column("FDBK_T")]
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
