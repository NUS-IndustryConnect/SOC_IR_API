using Microsoft.EntityFrameworkCore.Migrations;

namespace SOC_IR.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    adminId = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    announceId = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    subtitle = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    isImportant = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    validTill = table.Column<string>(nullable: true),
                    announcedBy = table.Column<string>(nullable: true),
                    lastUpdated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.announceId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    companyId = table.Column<string>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    companyTier = table.Column<string>(nullable: true),
                    companyDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPostRequests",
                columns: table => new
                {
                    companyPostRequestId = table.Column<string>(nullable: false),
                    companyId = table.Column<string>(nullable: true),
                    companyUserId = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    postTitle = table.Column<string>(nullable: true),
                    postSubTitle = table.Column<string>(nullable: true),
                    postDescription = table.Column<string>(nullable: true),
                    videoUrl = table.Column<string>(nullable: true),
                    links = table.Column<string>(nullable: true),
                    validTill = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    feedback = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPostRequests", x => x.companyPostRequestId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPosts",
                columns: table => new
                {
                    companyPostId = table.Column<string>(nullable: false),
                    companyId = table.Column<string>(nullable: true),
                    companyUserId = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    postTitle = table.Column<string>(nullable: true),
                    postSubTitle = table.Column<string>(nullable: true),
                    postDescription = table.Column<string>(nullable: true),
                    videoUrl = table.Column<string>(nullable: true),
                    links = table.Column<string>(nullable: true),
                    lastUpdated = table.Column<string>(nullable: true),
                    approvedBy = table.Column<string>(nullable: true),
                    validTill = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPosts", x => x.companyPostId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    companyUserId = table.Column<string>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    companyId = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    lastLoggedIn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.companyUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyPostRequests");

            migrationBuilder.DropTable(
                name: "CompanyPosts");

            migrationBuilder.DropTable(
                name: "CompanyUsers");
        }
    }
}
