using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class GetCompanyStudentDto
    {
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string companyDescription { get; set; }

        public GetCompanyStudentDto(string companyId, string companyName, string companyDescription)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyDescription = companyDescription;
        }
    }
}
