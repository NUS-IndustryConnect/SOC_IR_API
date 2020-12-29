using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SOC_IR.Dtos.Announcement;
using SOC_IR.Model;

namespace SOC_IR.Services.AnnouncementService
{
    public interface IAnnouncementService
    {
        Task<ServiceResponse<List<GetAnnouncementDto>>> GetAllAnnouncements();
        Task<ServiceResponse<GetAnnouncementDto>> GetAnnouncementById(string id);
        Task<ServiceResponse<List<GetAnnouncementDto>>> AddAnnouncement(AddAnnouncementDto newAnnouncement);
        Task<ServiceResponse<GetAnnouncementDto>> UpdateAnnouncement(UpdateAnnouncementDto updatedAnnouncement);
        Task<ServiceResponse<List<GetAnnouncementDto>>> DeleteAnnouncement(string id);
    }
}