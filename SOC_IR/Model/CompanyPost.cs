using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SOC_IR.Dtos.CompanyPostRequest;
using System.ComponentModel.DataAnnotations.Schema;
using SOC_IR.Dtos.CompanyPost;

namespace SOC_IR.Model
{
    [Table("IDC_POST", Schema = "OWNIDC")]
    public class CompanyPost
    {
        [Key]
        [Column("POST_ID")]
        public string companyPostId { get; set; }
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
        [Column("LAST_UPD_DTM")]
        public string lastUpdated { get; set; }
        [Column("APPV_NUSNET_ID")]
        public string approvedBy { get; set; }
        [Column("EXP_D")]
        public string validTill { get; set; }
        [Column("ACTIVE_F")]
        public Boolean isActive { get; set; }

        public CompanyPost(string companyPostId, string companyId, string companyUserId, string companyName, string postTitle, string postSubTitle, string postDescription,
            string videoUrl, string links, string lastUpdated, string approvedBy, string validTill, bool isActive)
        {
            this.companyPostId = companyPostId;
            this.companyId = companyId;
            this.companyUserId = companyUserId;
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

        public CompanyPost(string userId, ApprovalDto data)
        {
            this.companyPostId = data.request.companyPostRequestId;
            this.companyId = data.request.companyId;
            this.companyUserId = userId;
            this.companyName = data.companyName;
            this.postTitle = data.request.postTitle;
            this.postSubTitle = data.request.postSubTitle;
            this.postDescription = data.request.postDescription;
            this.videoUrl = data.request.videoUrl;
            this.links = data.request.links;
            this.lastUpdated = new DateTime().ToString();
            this.approvedBy = data.approvedBy;
            this.validTill = data.request.validTill;
            this.isActive = true;
        }

        public void archivePost()
        {
            this.isActive = false;
        }

        public void unarchivePost()
        {
            this.isActive = true;
        }

        public void companyUpdated(string companyName)
        {
            this.companyName = companyName;
        }

        public void update(UpdateCompanyPostDto update)
        {
            this.approvedBy = update.approvedBy;
            this.lastUpdated = DateTime.Now.ToString();
            this.postDescription = update.postDescription;
            this.postTitle = update.postTitle;
            this.postSubTitle = update.postSubTitle;
            this.videoUrl = update.videoUrl;
            this.validTill = update.validTill;
            this.links = update.links;
        }
    }
}
