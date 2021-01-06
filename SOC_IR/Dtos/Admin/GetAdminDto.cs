using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.AdminService
{
    public class GetAdminDto
    {
        public string adminID { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public GetAdminDto(string adminID, string name, string email)
        {
            this.adminID = adminID;
            this.name = name;
            this.email = email;
        }
    }
}
