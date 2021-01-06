using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Dtos.Company
{
    public class GetCompanyStudentDto
    {
        public string companyID { get; set; }
        public string companyName { get; set; }
        public string companyDescription { get; set; }

        public GetCompanyStudentDto(string companyID, string companyName, string companyDescription)
        {
            this.companyID = companyID;
            this.companyName = companyName;
            this.companyDescription = companyDescription;
        }
    }
}
