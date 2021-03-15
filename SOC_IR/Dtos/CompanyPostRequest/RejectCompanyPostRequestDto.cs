using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.CompanyPostRequest
{
    public class RejectCompanyPostRequestDto
    {
        public string companyPostRequestId { get; set; }
        public string feedback { get; set; }

    }
}
