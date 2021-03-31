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
        public DbSet<CompanyUserOtp> CompanyUserOtps { get; set; }
        public DbSet<CompanyUserToken> CompanyUserTokens { get; set; }
        public DbSet<NusUserToken> NusUserTokens { get; set; }
        public DbSet<StudentLogin> StudentLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyUserOtp>()
                .HasKey(o => new { o.companyUserId, o.logInTime });
            modelBuilder.Entity<StudentLogin>()
               .HasKey(o => new { o.nusnetId, o.logInTime });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=ownidc; Password=helloworld; Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = sidt.comp.nus.edu.sg)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = sidt.comp.nus.edu.sg)))");
        }
    }

}