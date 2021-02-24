using Microsoft.EntityFrameworkCore;
using SOC_IR.Data;
using SOC_IR.Dtos.CompanyUser;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyUserService
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly DataContext _context;
        public CompanyUserService(DataContext context)
        {
            _context = context;
        }
        async Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.CreateCompanyUser(CreateCompanyUserDto companyUserDto)
        {

            ServiceResponse<CompanyUserDto> response = new ServiceResponse<CompanyUserDto>();
            Company company = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == companyUserDto.companyId);
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.email == companyUserDto.email);
            if (user != null)
            {
                response.Success = false;
                response.Message = "This email already has an account";
                return response;
            }

            if (company == null)
            {
                response.Success = false;
                response.Message = "The company entered does not exist";
                return response;
            }

            string finalString = new IDGenerator.IDGenerator().generate();
            String lastLoggedIn = DateTime.Now.ToString();
            CompanyUser newUser = new CompanyUser(finalString, company.companyName, companyUserDto.companyId, companyUserDto.email, lastLoggedIn, true);
            await _context.CompanyUsers.AddAsync(newUser);
            await _context.SaveChangesAsync();
            CompanyUserDto newUserDto = new CompanyUserDto(newUser.companyUserId, newUser.companyId, newUser.companyName, newUser.email, newUser.lastLoggedIn, newUser.isActive);
            response.Data = newUserDto;
            return response;
        }

        async Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.DeleteCompanyUser(string companyUserID)
        {
            ServiceResponse<List<CompanyUserDto>> response = new ServiceResponse<List<CompanyUserDto>>();
            CompanyUser deleted = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.companyUserId == companyUserID);
            if(deleted == null)
            {
                response.Success = false;
                response.Message = "The account you want to delete does not exist";
                return response;
            }
            _context.CompanyUsers.Remove(deleted);
            await _context.SaveChangesAsync();
            List<CompanyUserDto> newList = await _context.CompanyUsers.Select(a=> new CompanyUserDto(a.companyUserId, a.companyId, a.companyName, a.email, a.lastLoggedIn, a.isActive)).ToListAsync();
            response.Data = newList;
            return response;

        }

        async Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.GetAllCompanyUsers()
        {
            ServiceResponse<List<CompanyUserDto>> response = new ServiceResponse<List<CompanyUserDto>>();
            List<CompanyUserDto> newList = await _context.CompanyUsers.Select(a => new CompanyUserDto(a.companyUserId, a.companyId, a.companyName, a.email, a.lastLoggedIn, a.isActive)).ToListAsync();
            response.Data = newList;
            return response;
        }

        async Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.GetCompanyUserFromId(string companyUserID)
        {
            ServiceResponse<CompanyUserDto> response = new ServiceResponse<CompanyUserDto>();
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(a => a.companyUserId == companyUserID);
            if (user == null)
            {
                response.Success = false;
                response.Message = "The user entered does not exist";
                return response;
            }
            CompanyUserDto userDto = new CompanyUserDto(user.companyUserId, user.companyId, user.companyName, user.email, user.lastLoggedIn, user.isActive);
            response.Data = userDto;
            return response;
        }

        async Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.GetCompanyUsersFromCompany(string companyId)
        {
            Company company = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == companyId);
            ServiceResponse<List<CompanyUserDto>> response = new ServiceResponse<List<CompanyUserDto>>();
            if (company == null)
            {
                response.Success = false;
                response.Message = "The company entered does not exist";
                return response;
            }
            List<CompanyUserDto> newList = await _context.CompanyUsers.Where(a=>a.companyId == companyId).Select(a => new CompanyUserDto(a.companyUserId, a.companyId, a.companyName, a.email, a.lastLoggedIn, a.isActive)).ToListAsync();
            response.Data = newList;
            return response;
        }

        async Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.ArchiveUser(string id)
        {
            ServiceResponse<CompanyUserDto> response = new ServiceResponse<CompanyUserDto>();
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(async => async.companyUserId == id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "The company user you wish to archive does not exist";
                return response;
            }
            user.archiveUser();
            _context.CompanyUsers.Update(user);
            await _context.SaveChangesAsync();
            CompanyUserDto userDto = new CompanyUserDto(user.companyUserId, user.companyId, user.companyName, user.email, user.lastLoggedIn, user.isActive);
            response.Data = userDto;
            return response;
        }

        async Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.UnarchiveUser(string id)
        {
            ServiceResponse<CompanyUserDto> response = new ServiceResponse<CompanyUserDto>();
            CompanyUser user = await _context.CompanyUsers.FirstOrDefaultAsync(async => async.companyUserId == id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "The company user you wish to archive does not exist";
                return response;
            }
            user.unarchiveUser();
            _context.CompanyUsers.Update(user);
            await _context.SaveChangesAsync();
            CompanyUserDto userDto = new CompanyUserDto(user.companyUserId, user.companyId, user.companyName, user.email, user.lastLoggedIn, user.isActive);
            response.Data = userDto;
            return response;
        }
    }
}
