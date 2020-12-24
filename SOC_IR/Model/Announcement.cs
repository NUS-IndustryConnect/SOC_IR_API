using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    public class Announcement
    {
        [Key]
        public string announceId { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public Boolean isImportant { get; set; }
        public Boolean isActive { get; set; }
        public string validTill { get; set; }
        public string announcedBy { get; set; }
    }
}
