using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SOC_IR.Data;
using SOC_IR.Dtos.Announcement;
using SOC_IR.Model;

namespace SOC_IR.Services.AnnouncementService
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AnnouncementService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetAnnouncementDto>>> AddAnnouncement(AddAnnouncementDto newAnnouncement)
        {
            ServiceResponse<List<GetAnnouncementDto>> serviceResponse = new ServiceResponse<List<GetAnnouncementDto>>();
            Announcement announcement = _mapper.Map<Announcement>(newAnnouncement);
            announcement.isActive = true;
            announcement.lastUpdated = new DateTime().ToString();

            await _context.Announcements.AddAsync(announcement);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Announcements.Select(a => _mapper.Map<GetAnnouncementDto>(a))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAnnouncementDto>>> GetAllAnnouncements()
        {
            ServiceResponse<List<GetAnnouncementDto>> serviceResponse = new ServiceResponse<List<GetAnnouncementDto>>();
            List<Announcement> dbAnnouncements = await _context.Announcements.ToListAsync();
            serviceResponse.Data = (dbAnnouncements.Select(a => _mapper.Map<GetAnnouncementDto>(a))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentAnnouncementDto>>> GetAllUnarchivedAnnouncements()
        {
            ServiceResponse<List<GetStudentAnnouncementDto>> serviceResponse = new ServiceResponse<List<GetStudentAnnouncementDto>>();
            List<Announcement> dbAnnouncements = await _context.Announcements.Where(a => a.isActive == true).ToListAsync();
            serviceResponse.Data = (dbAnnouncements.Select(a => _mapper.Map<GetStudentAnnouncementDto>(a))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAnnouncementDto>> GetAnnouncementById(string id)
        {
            ServiceResponse<GetAnnouncementDto> serviceResponse = new ServiceResponse<GetAnnouncementDto>();
            Announcement dbAnnouncement = await _context.Announcements.FirstOrDefaultAsync(a => a.announceId == id);
            serviceResponse.Data = _mapper.Map<GetAnnouncementDto>(dbAnnouncement);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAnnouncementDto>> UpdateAnnouncement(UpdateAnnouncementDto updatedAnnouncement)
        {
            ServiceResponse<GetAnnouncementDto> serviceResponse = new ServiceResponse<GetAnnouncementDto>();
            try {
                Announcement announcement = await _context.Announcements.FirstOrDefaultAsync(a => a.announceId == updatedAnnouncement.announceID);
                announcement.title = updatedAnnouncement.title;
                announcement.subtitle = updatedAnnouncement.subtitle;
                announcement.description = updatedAnnouncement.description;
                announcement.isImportant = updatedAnnouncement.isImportant;
                announcement.validTill = updatedAnnouncement.validTill;
                announcement.lastUpdated = new DateTime().ToString();

                _context.Announcements.Update(announcement);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetAnnouncementDto>(announcement);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAnnouncementDto>>> DeleteAnnouncement(string id)
        {
            ServiceResponse<List<GetAnnouncementDto>> serviceResponse = new ServiceResponse<List<GetAnnouncementDto>>();
            try
            {
                Announcement announcement = await _context.Announcements.FirstAsync(a => a.announceId == id);
                _context.Announcements.Remove(announcement);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Announcements.Select(a => _mapper.Map<GetAnnouncementDto>(a))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAnnouncementDto>> ArchiveAnnouncement(String announceID)
        {
            ServiceResponse<GetAnnouncementDto> serviceResponse = new ServiceResponse<GetAnnouncementDto>();
            try
            {
                Announcement announcement = await _context.Announcements.FirstOrDefaultAsync(a => a.announceId == announceID);
                announcement.isActive = false;

                _context.Announcements.Update(announcement);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetAnnouncementDto>(announcement);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}