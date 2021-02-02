using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Model
{
    [Table("IDC_ANNOUNCE", Schema = "OWNIDC")]
    public class Announcement
    {
        [Key]
        [Column("ANNOUNCE_ID")]
        public string announceId { get; set; }
        [Column("TITLE_T")]
        public string title { get; set; }
        [Column("SUBTITLE_T")]
        public string subtitle { get; set; }
        [Column("DESC_T")]
        public string description { get; set; }
        [Column("IMPORTANT_F")]
        public Boolean isImportant { get; set; }
        [Column("ACTIVE_F")]
        public Boolean isActive { get; set; }
        [Column("EXP_D")]
        public string validTill { get; set; }
        [Column("CREATE_NUSNET_ID")]
        public string announcedBy { get; set; }
        [Column("LAST_UPD_DTM")]
        public string lastUpdated { get; set; }
    }
}
