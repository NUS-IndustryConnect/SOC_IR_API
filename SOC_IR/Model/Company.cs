using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SOC_IR.Model
{
    public class Company
    {
        [Key]
        public string companyID { get; set; }
        public string companyName { get; set; }
        public string companyTier { get; set; }
        public string companyDescription { get; set; }
        public List<string> companyPostIdList { get; set; }
        public List<string> companyPostRequestIdList { get; set; }

        public Company(string companyID, string companyName, string companyTier, string companyDescription, List<string> companyPostIdList, List<string> companyPostRequestIdList)
        {
            this.companyID = companyID;
            this.companyName = companyName;
            this.companyTier = companyTier;
            this.companyDescription = companyDescription;
            this.companyPostIdList = companyPostIdList;
            this.companyPostRequestIdList = companyPostRequestIdList;
        }

        public void addPost(string postID)
        {
            this.companyPostIdList.Add(postID);
        }

        public void addPostRequest(string postID)
        {
            this.companyPostRequestIdList.Add(postID);
        }

        public void approvePostRequest(string postID)
        {
            this.companyPostRequestIdList.Remove(postID);
            this.companyPostIdList.Add(postID);
        }

        public void deletePost(string postID)
        {
            this.companyPostIdList.Remove(postID);
        }

        public void deletePosts(List<string> postIDs)
        {
            for (int i = 0; i < postIDs.Count(); i++)
            {
                string postID = postIDs[i];
                if (this.companyPostIdList.Contains(postID))
                {
                    companyPostIdList.Remove(postID);
                }
            }
        }
    }
}
