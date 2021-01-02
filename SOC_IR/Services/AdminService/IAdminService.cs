using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.AdminService
{
    public interface IAdminService
    {
        public Task<ServiceResponse<List<GetAdminDto>>> GetAllAdmin();
        public Task<ServiceResponse<GetAdminDto>> GetAdminById(string id);

    }
}
