using System;

namespace SOC_IR.Dtos.Announcement
{
    public class GetStudentAnnouncementDto
    {
        public string announceID { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public Boolean isImportant { get; set; }
        public string validTill { get; set; }
        public string lastUpdated { get; set; }
    }
}