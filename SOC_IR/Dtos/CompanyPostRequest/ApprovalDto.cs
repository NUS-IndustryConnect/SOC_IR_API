using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOC_IR.Model;

namespace SOC_IR.Dtos.CompanyPostRequest
{
    public class ApprovalDto
    {
        public SOC_IR.Model.CompanyPostRequest request;
        public string companyName;
        public string approvedBy;

        public ApprovalDto(Model.CompanyPostRequest request, string companyName, string approvedBy)
        {
            this.request = request;
            this.companyName = companyName;
            this.approvedBy = approvedBy;
        }
    }
}
