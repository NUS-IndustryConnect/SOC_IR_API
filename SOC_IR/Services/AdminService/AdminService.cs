using SOC_IR.Data;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _context;
        public AdminService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<GetAdminDto>> GetAdminById(string id)
        {
            ServiceResponse<GetAdminDto> response = new ServiceResponse<GetAdminDto>();
            Admin admin = await _context.Admins.FirstAsync(a => a.adminID == id);
            GetAdminDto adminDto = new GetAdminDto(admin.adminID, admin.name, admin.email);
            response.Data = adminDto;
            return response;

        }

        public async Task<ServiceResponse<List<GetAdminDto>>> GetAllAdmin()
        {
            ServiceResponse<List<GetAdminDto>> response = new ServiceResponse<List<GetAdminDto>>();
            List<GetAdminDto> admins = await _context.Admins.Select(admin => new GetAdminDto(admin.adminID, admin.name, admin.email)).ToListAsync();
            response.Data = admins;
            return response;
        }
    }
}
