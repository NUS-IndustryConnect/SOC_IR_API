﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using SOC_IR.Data;

namespace SOC_IR.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("SOC_IR.Model.Admin", b =>
                {
                    b.Property<string>("nusNetId")
                        .HasColumnName("NUSNET_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("email")
                        .HasColumnName("EMADDR_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("name")
                        .HasColumnName("ADMIN_NM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("nusNetId");

                    b.ToTable("IDC_ADMIN","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.Announcement", b =>
                {
                    b.Property<string>("announceId")
                        .HasColumnName("ANNOUNCE_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("announcedBy")
                        .HasColumnName("CREATE_NUSNET_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("description")
                        .HasColumnName("DESC_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("isActive")
                        .HasColumnName("ACTIVE_F")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("isImportant")
                        .HasColumnName("IMPORTANT_F")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("lastUpdated")
                        .HasColumnName("LAST_UPD_DTM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("subtitle")
                        .HasColumnName("SUBTITLE_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("title")
                        .HasColumnName("TITLE_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("validTill")
                        .HasColumnName("EXP_D")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("announceId");

                    b.ToTable("IDC_ANNOUNCE","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.Company", b =>
                {
                    b.Property<string>("companyId")
                        .HasColumnName("ORGN_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("companyDescription")
                        .HasColumnName("DESC_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyName")
                        .HasColumnName("ORGN_NM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyTier")
                        .HasColumnName("TIER_C")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("isActive")
                        .HasColumnName("ACTIVE_F")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("companyId");

                    b.ToTable("IDC_ORGN","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.CompanyPost", b =>
                {
                    b.Property<string>("companyPostId")
                        .HasColumnName("POST_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("approvedBy")
                        .HasColumnName("APPV_NUSNET_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyId")
                        .HasColumnName("ORGN_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyName")
                        .HasColumnName("ORGN_NM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyUserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("isActive")
                        .HasColumnName("ACTIVE_F")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("lastUpdated")
                        .HasColumnName("LAST_UPD_DTM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("links")
                        .HasColumnName("LINK_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("postDescription")
                        .HasColumnName("DESC_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("postSubTitle")
                        .HasColumnName("SUBTITLE_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("postTitle")
                        .HasColumnName("TITLE_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("validTill")
                        .HasColumnName("EXP_D")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("videoUrl")
                        .HasColumnName("VIDEO_URL_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("companyPostId");

                    b.ToTable("IDC_POST","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.CompanyPostRequest", b =>
                {
                    b.Property<string>("companyPostRequestId")
                        .HasColumnName("POST_REQ_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("companyId")
                        .HasColumnName("ORGN_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyName")
                        .HasColumnName("ORGN_NM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyUserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("feedback")
                        .HasColumnName("FDBK_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("links")
                        .HasColumnName("LINK_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("postDescription")
                        .HasColumnName("DESC_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("postSubTitle")
                        .HasColumnName("SUBTITLE_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("postTitle")
                        .HasColumnName("TITLE_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("status")
                        .HasColumnName("STATUS_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("validTill")
                        .HasColumnName("EXP_D")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("videoUrl")
                        .HasColumnName("VIDEO_URL_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("companyPostRequestId");

                    b.ToTable("IDC_POST_REQ","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.CompanyUser", b =>
                {
                    b.Property<string>("companyUserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("companyId")
                        .HasColumnName("ORGN_ID")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("companyName")
                        .HasColumnName("ORGN_NM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("email")
                        .HasColumnName("EMADDR_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("isActive")
                        .HasColumnName("ACTIVE_F")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("lastLoggedIn")
                        .HasColumnName("LAST_LOGIN_DTM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("companyUserId");

                    b.ToTable("IDC_ORGN_USER","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.CompanyUserOtp", b =>
                {
                    b.Property<string>("companyUserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("logInTime")
                        .HasColumnName("LOGIN_DTM")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("email")
                        .HasColumnName("EMADDR_T")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("isExpired")
                        .HasColumnName("IS_EXPIRED")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("otp")
                        .HasColumnName("OTP")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("otpAttemptCount")
                        .HasColumnName("OTP_ATTEMPT_COUNT")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("companyUserId", "logInTime");

                    b.ToTable("IDC_ORGN_USER_LOGIN","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.CompanyUserToken", b =>
                {
                    b.Property<string>("companyUserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("logInTime")
                        .HasColumnName("LOGIN_DTM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("token")
                        .HasColumnName("TOKEN")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("companyUserId");

                    b.ToTable("IDC_ORGN_USER_TOKEN","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.NusUserToken", b =>
                {
                    b.Property<string>("nusnetId")
                        .HasColumnName("NUSNET_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("logInTime")
                        .HasColumnName("LOGIN_DTM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("token")
                        .HasColumnName("TOKEN")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("nusnetId");

                    b.ToTable("IDC_NUS_USER_TOKEN","OWNIDC");
                });

            modelBuilder.Entity("SOC_IR.Model.StudentLogin", b =>
                {
                    b.Property<string>("nusnetId")
                        .HasColumnName("NUSNET_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("logInTime")
                        .HasColumnName("LOGIN_DTM")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("nusnetId", "logInTime");

                    b.ToTable("IDC_STD_USER_LOGIN","OWNIDC");
                });
#pragma warning restore 612, 618
        }
    }
}
