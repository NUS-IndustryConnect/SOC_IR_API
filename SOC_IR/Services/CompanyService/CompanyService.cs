using SOC_IR.Data;
using SOC_IR.Dtos.Company;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;
        public CompanyService(DataContext context)
        {
            _context = context;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.CreateCompany(CreateCompanyDto companyDto)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            if (_context.Companies.First(a => a.companyName == companyDto.companyName) != null)
            {
                response.Success = false;
                response.Message = "This company already has an account";
                return response;
            }

            string finalString = new IDGenerator.IDGenerator().generate();
            List<string> postList = new List<string>();

            Company newCompany = new Company(finalString, companyDto.companyName, companyDto.companyTier, companyDto.companyDescription, postList);
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> data = newCompanyList.Select(a => new GetCompanyAdminDto(a.companyID, a.companyName, a.companyTier, a.companyDescription, a.companyPostIdList)).ToList();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.DeleteCompany(string id)
        {
            Company removed = await _context.Companies.FirstAsync(a => a.companyID == id);
            List<CompanyUser> users = await _context.CompanyUsers.Where(a => a.companyID == id).ToListAsync();
            _context.Companies.Remove(removed);
            _context.CompanyUsers.RemoveRange(users);
            await _context.SaveChangesAsync();
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> data = newCompanyList.Select(a => new GetCompanyAdminDto(a.companyID, a.companyName, a.companyTier, a.companyDescription, a.companyPostIdList)).ToList();
            response.Data =data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.GetCompanyAdmin()
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> data = newCompanyList.Select(a => new GetCompanyAdminDto(a.companyID, a.companyName, a.companyTier, a.companyDescription, a.companyPostIdList)).ToList();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyStudentDto>>> ICompanyService.GetCompanyStudent()
        {
            ServiceResponse<List<GetCompanyStudentDto>> response = new ServiceResponse<List<GetCompanyStudentDto>>();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            List<GetCompanyStudentDto> data = newCompanyList.Select(a => new GetCompanyStudentDto(a.companyID, a.companyName, a.companyDescription)).ToList();
            response.Data = data;
            return response;
        }

        async Task<ServiceResponse<GetCompanyAdminDto>> ICompanyService.UpdateCompany(UpdateCompanyDto updatedCompanyDto)
        {
            Company update = await _context.Companies.FirstAsync(a => a.companyID == updatedCompanyDto.companyID);
            Company updated = new Company(updatedCompanyDto.companyID, updatedCompanyDto.companyName, updatedCompanyDto.companyTier,
                updatedCompanyDto.companyDescription, update.companyPostIdList);


            if(update.companyName != updated.companyName)
            {
                List<CompanyPost> posts = await _context.CompanyPosts.Where(a => a.companyID == updatedCompanyDto.companyID).ToListAsync();
                posts.ForEach(a => a.companyUpdated(updatedCompanyDto.companyName));
                _context.CompanyPosts.UpdateRange(posts);
            }


            _context.Companies.Update(updated);
            await _context.SaveChangesAsync();
            ServiceResponse<GetCompanyAdminDto> response= new ServiceResponse<GetCompanyAdminDto>();
            GetCompanyAdminDto data = new GetCompanyAdminDto(updated.companyID, updated.companyName, updated.companyTier, updated.companyDescription, updated.companyPostIdList);
            response.Data = data;
            return response;
        }
    }
}
