using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SOC_IR.Data;
using SOC_IR.Dtos.Company;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CompanyService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.CreateCompany(CreateCompanyDto companyDto)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            if (await _context.Companies.FirstOrDefaultAsync(a => a.companyName == companyDto.companyName) != null)
            {
                response.Success = false;
                response.Message = "This company already has an account";
                return response;
            }

            string finalString = new IDGenerator.IDGenerator().generate();

            Company newCompany = new Company(finalString, companyDto.companyName, companyDto.companyTier, companyDto.companyDescription, true);
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            response.Data = newCompanyList.Select(a => new GetCompanyAdminDto(a.companyId, a.companyName, a.companyTier, a.companyDescription, a.isActive)).ToList(); ;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.DeleteCompany(string id)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            Company removed = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == id);

            if(removed == null)
            {
                response.Success = false;
                response.Message = "This company does not exist";
                return response;
            }

            List<CompanyUser> users = await _context.CompanyUsers.Where(a => a.companyId == id).ToListAsync();
            List<CompanyPost> posts = await _context.CompanyPosts.Where(a => a.companyId == id).ToListAsync();
            List<CompanyPostRequest> requests = await _context.CompanyPostRequests.Where(a => a.companyId == id).ToListAsync();
            _context.Companies.Remove(removed);
            _context.CompanyUsers.RemoveRange(users);
            _context.CompanyPosts.RemoveRange(posts);
            _context.CompanyPostRequests.RemoveRange(requests);
            await _context.SaveChangesAsync();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> data = newCompanyList.Select(a => new GetCompanyAdminDto(a.companyId, a.companyName, a.companyTier, a.companyDescription, a.isActive)).ToList();
            response.Data =data;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.GetCompanyAdmin()
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            List<Company> comps = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> dataList = comps.Select(a =>  _mapper.Map<GetCompanyAdminDto>(a)).ToList();
            response.Data = dataList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyStudentDto>>> ICompanyService.GetCompanyStudent()
        {
            ServiceResponse<List<GetCompanyStudentDto>> response = new ServiceResponse<List<GetCompanyStudentDto>>();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            List<GetCompanyStudentDto> data = newCompanyList.Select(a => new GetCompanyStudentDto(a.companyId, a.companyName, a.companyDescription)).ToList();
            response.Data = data;
            return response;
        }

        //currently supports updating archived posts, seek clarification
        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.UpdateCompany(string companyId, UpdateCompanyDto updatedCompanyDto)
        {
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            Company update = await _context.Companies.FirstOrDefaultAsync(a => a.companyId == companyId);
            if (update == null)
            {
                response.Success = false;
                response.Message = "This company does not exist";
                return response;
            }

            string oldname = update.companyName;
            update.companyName = updatedCompanyDto.companyName;
            update.companyTier = updatedCompanyDto.companyTier;
            update.companyDescription = updatedCompanyDto.companyDescription;

            if (oldname != update.companyName)
            {
                List<CompanyPost> posts = await _context.CompanyPosts.Where(a => a.companyId == companyId).ToListAsync();
                if(posts.Count != 0)
                {
                    posts.ForEach(a => a.companyUpdated(updatedCompanyDto.companyName));
                    _context.CompanyPosts.UpdateRange(posts);
                }
                List<CompanyPostRequest> requests = await _context.CompanyPostRequests.Where(a => a.companyId == companyId).ToListAsync();
                if (requests.Count != 0)
                {
                    requests.ForEach(a => a.companyUpdated(updatedCompanyDto.companyName));
                    _context.CompanyPostRequests.UpdateRange(requests);
                }
            }

            _context.Companies.Update(update);
            await _context.SaveChangesAsync();
            List<Company> comps = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> dataList = comps.Select(a => _mapper.Map<GetCompanyAdminDto>(a)).ToList();
            response.Data = dataList;
            return response;
        }

        async Task<ServiceResponse<List<GetCompanyAdminDto>>> ICompanyService.ArchiveCompany(string companyId)
        {
            Company company = await _context.Companies.FirstAsync(a => a.companyId == companyId);
            ServiceResponse<List<GetCompanyAdminDto>> response = new ServiceResponse<List<GetCompanyAdminDto>>();
            if (company == null)
            {
                response.Success = false;
                response.Message = "This company does not exist";
                return response;
            }
            List<CompanyPost> companyPosts = await _context.CompanyPosts.Where(a => a.companyId == company.companyId).ToListAsync();
            companyPosts.ForEach(a => a.archivePost());
            List<CompanyPostRequest> requests = await _context.CompanyPostRequests.Where(a => a.companyId == company.companyId).ToListAsync();
            List<CompanyUser> companyUsers = await _context.CompanyUsers.Where(a => a.companyId == company.companyId).ToListAsync();
            companyUsers.ForEach(a => a.archiveUser());

            _context.CompanyPosts.UpdateRange(companyPosts);
            _context.CompanyPostRequests.RemoveRange(requests);

            company = company.archive();
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            List<Company> comps = await _context.Companies.ToListAsync();
            List<GetCompanyAdminDto> dataList = comps.Select(a => _mapper.Map<GetCompanyAdminDto>(a)).ToList();
            response.Data = dataList;
            return response;
        }

        async Task<ServiceResponse<List<Company>>> ICompanyService.GetCompany()
        {
            ServiceResponse<List<Company>> response = new ServiceResponse<List<Company>>();
            List<Company> newCompanyList = await _context.Companies.ToListAsync();
            response.Data = newCompanyList;
            return response;
        }
    }
}
