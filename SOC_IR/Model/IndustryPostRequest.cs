using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    public class IndustryPostRequest
    {
        private string industryPostRequestID { get; set; }
        private string companyID { get; set; }
        private string postTitle { get; set; }
        private string postSubTitle { get; set; }
        private string postDescription { get; set; }
        private string videoUrl { get; set; }
        private string links { get; set; }
        private string validTill { get; set; }
        private string status { get; set; }
        private string feedback { get; set; }
    }
}
