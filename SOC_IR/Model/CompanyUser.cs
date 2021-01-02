using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class CompanyUser
    {
        [Key]
        public string companyUserID { get; set; }
        public string companyID { get; set; }
        public string email { get; set; }
        public string lastLoggedIn { get; set; }
        public List<string> companyUserPostIds { get; set; }

        public CompanyUser(string companyUserID, string companyID, string email, string lastLoggedIn, List<string> companyUserPostIds)
        {
            this.companyUserID = companyUserID;
            this.companyID = companyID;
            this.email = email;
            this.lastLoggedIn = lastLoggedIn;
            this.companyUserPostIds = companyUserPostIds;
        }

        public void addPost(string postID)
        {
            this.companyUserPostIds.Add(postID);
        }

        public void deletePost(string postID)
        {
            this.companyUserPostIds.Remove(postID);
        }

        public void deletePosts(List<string> postIDs)
        {
            for (int i = 0; i < postIDs.Count(); i++)
            {
                string postID = postIDs[i];
                if (this.companyUserPostIds.Contains(postID))
                {
                    companyUserPostIds.Remove(postID);
                }
            }
        }
    }
}
