using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class CreateCompanyPostDto
    {
        public string companyId { get; set; }
        public string companyUserId { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string approvedBy { get; set; }
        public string validTill { get; set; }

    }
}
