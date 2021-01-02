using SOC_IR.Data;
using SOC_IR.Dtos.CompanyUser;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Company company = await _context.Companies.FirstAsync(a => a.companyID == companyUserDto.companyID);
            if (await _context.CompanyUsers.FirstAsync(a => a.email == companyUserDto.email) == null)
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
            List<string> postList = new List<string>();
            String lastLoggedIn = new DateTime().ToString();
            CompanyUser newUser = new CompanyUser(finalString, companyUserDto.companyID, companyUserDto.email, lastLoggedIn, postList);
            await _context.CompanyUsers.AddAsync(newUser);
            await _context.SaveChangesAsync();
            CompanyUserDto newUserDto = new CompanyUserDto(newUser.companyUserID, newUser.companyID, newUser.email, newUser.lastLoggedIn, newUser.companyUserPostIds);
            response.Data = newUserDto;
            return response;
        }

        async Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.DeleteCompanyUser(string companyUserID)
        {
            ServiceResponse<List<CompanyUserDto>> response = new ServiceResponse<List<CompanyUserDto>>();
            CompanyUser deleted = await _context.CompanyUsers.FirstAsync(a => a.companyUserID == companyUserID);
            _context.CompanyUsers.Remove(deleted);
            await _context.SaveChangesAsync();
            List<CompanyUserDto> newList = await _context.CompanyUsers.Select(a=> new CompanyUserDto(a.companyUserID, a.companyID, a.email, a.lastLoggedIn,a.companyUserPostIds)).ToListAsync();
            response.Data = newList;
            return response;

        }

        async Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.GetAllCompanyUsers()
        {
            ServiceResponse<List<CompanyUserDto>> response = new ServiceResponse<List<CompanyUserDto>>();
            List<CompanyUserDto> newList = await _context.CompanyUsers.Select(a => new CompanyUserDto(a.companyUserID, a.companyID, a.email, a.lastLoggedIn, a.companyUserPostIds)).ToListAsync();
            response.Data = newList;
            return response;
        }

        async Task<ServiceResponse<CompanyUserDto>> ICompanyUserService.GetCompanyUserFromId(string companyUserID)
        {
            ServiceResponse<CompanyUserDto> response = new ServiceResponse<CompanyUserDto>();
            CompanyUser user = await _context.CompanyUsers.FirstAsync(a => a.companyUserID == companyUserID);
            CompanyUserDto userDto = new CompanyUserDto(user.companyUserID, user.companyID, user.email, user.lastLoggedIn, user.companyUserPostIds);
            response.Data = userDto;
            return response;
        }

        async Task<ServiceResponse<List<CompanyUserDto>>> ICompanyUserService.GetCompanyUsersFromCompany(string companyID)
        {
            ServiceResponse<List<CompanyUserDto>> response = new ServiceResponse<List<CompanyUserDto>>();
            List<CompanyUserDto> newList = await _context.CompanyUsers.Where(a=>a.companyID == companyID).Select(a => new CompanyUserDto(a.companyUserID, a.companyID, a.email, a.lastLoggedIn, a.companyUserPostIds)).ToListAsync();
            response.Data = newList;
            return response;
        }
    }
}
