using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPostRequest
{
    public class CreateCompanyPostRequestDto
    {
        public string companyID { get; set; }
        public string companyUserID { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public List<string>  links { get; set; }
        public string validTill { get; set; }
    }
}
