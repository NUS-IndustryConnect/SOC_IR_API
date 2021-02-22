using AutoMapper;
using SOC_IR.Dtos.Announcement;
using SOC_IR.Dtos.Company;
using SOC_IR.Model;

namespace SOC_IR
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Announcement, GetAnnouncementDto>();
            CreateMap<Announcement, GetStudentAnnouncementDto>();
            CreateMap<AddAnnouncementDto, Announcement>();
            CreateMap<ArchiveAnnouncementDto, Announcement>();
            CreateMap<Company, GetCompanyAdminDto>();
            CreateMap<Company, GetCompanyStudentDto>();
        
        }
    }
}