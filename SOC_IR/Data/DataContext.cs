using Microsoft.EntityFrameworkCore;
using SOC_IR.Model;

namespace SOC_IR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<CompanyPost> CompanyPosts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CompanyPostRequest> CompanyPostRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=prjidc; Password=industr4connec4; Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = sidt.comp.nus.edu.sg)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = sidt.comp.nus.edu.sg)))");
        }
    }

}