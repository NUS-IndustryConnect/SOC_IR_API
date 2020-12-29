using Microsoft.EntityFrameworkCore;
using SOC_IR.Model;

namespace SOC_IR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Announcement> Announcements { get; set; }
    }
}