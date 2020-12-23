using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    public class Announcement
    {
        private string announceID { get; set; }
        private string title { get; set; }
        private string subtitle { get; set; }
        private string description { get; set; }
        private Boolean isImportant { get; set; }
        private Boolean isActive { get; set; }
        private string validTill { get; set; }
        private string announcedBy { get; set; }
    }
}
