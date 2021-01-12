using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.AdminService
{
    public class GetAdminDto
    {
        public string adminId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public GetAdminDto(string adminId, string name, string email)
        {
            this.adminId = adminId;
            this.name = name;
            this.email = email;
        }
    }
}
