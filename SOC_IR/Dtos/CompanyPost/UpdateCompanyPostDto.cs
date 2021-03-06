﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPost
{
    public class UpdateCompanyPostDto
    {
        public string companyPostId { get; set; }
        public string postTitle { get; set; }
        public string postSubTitle { get; set; }
        public string postDescription { get; set; }
        public string videoUrl { get; set; }
        public string links { get; set; }
        public string approvedBy { get; set; }
        public string validTill { get; set; }
    }
}
