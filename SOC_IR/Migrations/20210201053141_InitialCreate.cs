using Microsoft.EntityFrameworkCore.Migrations;

namespace SOC_IR.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OWNIDC");

            migrationBuilder.CreateTable(
                name: "IDC_ADMIN",
                schema: "OWNIDC",
                columns: table => new
                {
                    NUSNET_ID = table.Column<string>(nullable: false),
                    ADMIN_NM = table.Column<string>(nullable: true),
                    EMADDR_T = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDC_ADMIN", x => x.NUSNET_ID);
                });

            migrationBuilder.CreateTable(
                name: "IDC_ANNOUNCE",
                schema: "OWNIDC",
                columns: table => new
                {
                    ANNOUNCE_ID = table.Column<string>(nullable: false),
                    TITLE_T = table.Column<string>(nullable: true),
                    SUBTITLE_T = table.Column<string>(nullable: true),
                    DESC_T = table.Column<string>(nullable: true),
                    IMPORTANT_F = table.Column<bool>(nullable: false),
                    ACTIVE_F = table.Column<bool>(nullable: false),
                    EXP_D = table.Column<string>(nullable: true),
                    CREATE_NUSNET_ID = table.Column<string>(nullable: true),
                    LAST_UPD_DTM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDC_ANNOUNCE", x => x.ANNOUNCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "IDC_ORGN",
                schema: "OWNIDC",
                columns: table => new
                {
                    ORGN_ID = table.Column<string>(nullable: false),
                    ORGN_NM = table.Column<string>(nullable: true),
                    TIER_C = table.Column<string>(nullable: true),
                    DESC_T = table.Column<string>(nullable: true),
                    ACTIVE_F = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDC_ORGN", x => x.ORGN_ID);
                });

            migrationBuilder.CreateTable(
                name: "IDC_ORGN_USER",
                schema: "OWNIDC",
                columns: table => new
                {
                    USER_ID = table.Column<string>(nullable: false),
                    ORGN_ID = table.Column<string>(nullable: true),
                    ORGN_NM = table.Column<string>(nullable: true),
                    EMADDR_T = table.Column<string>(nullable: true),
                    LAST_LOGIN_DTM = table.Column<string>(nullable: true),
                    ACTIVE_F = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDC_ORGN_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "IDC_POST",
                schema: "OWNIDC",
                columns: table => new
                {
                    POST_ID = table.Column<string>(nullable: false),
                    ORGN_ID = table.Column<string>(nullable: true),
                    USER_ID = table.Column<string>(nullable: true),
                    ORGN_NM = table.Column<string>(nullable: true),
                    TITLE_T = table.Column<string>(nullable: true),
                    SUBTITLE_T = table.Column<string>(nullable: true),
                    DESC_T = table.Column<string>(nullable: true),
                    VIDEO_URL_T = table.Column<string>(nullable: true),
                    LINK_T = table.Column<string>(nullable: true),
                    LAST_UPD_DTM = table.Column<string>(nullable: true),
                    APPV_NUSNET_ID = table.Column<string>(nullable: true),
                    EXP_D = table.Column<string>(nullable: true),
                    ACTIVE_F = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDC_POST", x => x.POST_ID);
                });

            migrationBuilder.CreateTable(
                name: "IDC_POST_REQ",
                schema: "OWNIDC",
                columns: table => new
                {
                    POST_REQ_ID = table.Column<string>(nullable: false),
                    ORGN_ID = table.Column<string>(nullable: true),
                    USER_ID = table.Column<string>(nullable: true),
                    ORGN_NM = table.Column<string>(nullable: true),
                    TITLE_T = table.Column<string>(nullable: true),
                    SUBTITLE_T = table.Column<string>(nullable: true),
                    DESC_T = table.Column<string>(nullable: true),
                    VIDEO_URL_T = table.Column<string>(nullable: true),
                    LINK_T = table.Column<string>(nullable: true),
                    EXP_D = table.Column<string>(nullable: true),
                    STATUS_T = table.Column<string>(nullable: true),
                    FDBK_T = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDC_POST_REQ", x => x.POST_REQ_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IDC_ADMIN",
                schema: "OWNIDC");

            migrationBuilder.DropTable(
                name: "IDC_ANNOUNCE",
                schema: "OWNIDC");

            migrationBuilder.DropTable(
                name: "IDC_ORGN",
                schema: "OWNIDC");

            migrationBuilder.DropTable(
                name: "IDC_ORGN_USER",
                schema: "OWNIDC");

            migrationBuilder.DropTable(
                name: "IDC_POST",
                schema: "OWNIDC");

            migrationBuilder.DropTable(
                name: "IDC_POST_REQ",
                schema: "OWNIDC");
        }
    }
}
