using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Data;

namespace WebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161116161814_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserClaim<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("ProviderKey")
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserLogin<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserRole<int>");
                });

            modelBuilder.Entity("WebApplication.Data.Checkups", b =>
                {
                    b.Property<int>("CheckupsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Patients");

                    b.Property<DateTimeOffset>("Period");

                    b.HasKey("CheckupsID");

                    b.ToTable("Checkups");
                });

            modelBuilder.Entity("WebApplication.Data.CheckupsDone", b =>
                {
                    b.Property<int>("CheckupsDoneID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MotherID");

                    b.Property<int>("Patients");

                    b.HasKey("CheckupsDoneID");

                    b.HasIndex("MotherID");

                    b.ToTable("CheckupsDone");
                });

            modelBuilder.Entity("WebApplication.Data.Child", b =>
                {
                    b.Property<int>("ChildID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BGroup");

                    b.Property<DateTimeOffset>("DOB");

                    b.Property<int>("MotherID");

                    b.Property<string>("Name");

                    b.HasKey("ChildID");

                    b.HasIndex("MotherID");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("WebApplication.Data.Mother", b =>
                {
                    b.Property<int>("MotherID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<string>("PhoneNo");

                    b.HasKey("MotherID");

                    b.ToTable("Mothers");
                });

            modelBuilder.Entity("WebApplication.Data.MotherExamination", b =>
                {
                    b.Property<int>("ExaminationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Advice");

                    b.Property<string>("BloodPressure");

                    b.Property<string>("Complication");

                    b.Property<string>("HBTest");

                    b.Property<decimal>("Height");

                    b.Property<string>("Medication");

                    b.Property<int>("MotherID");

                    b.Property<decimal>("Weight");

                    b.HasKey("ExaminationID");

                    b.HasIndex("MotherID");

                    b.ToTable("Examination");
                });

            modelBuilder.Entity("WebApplication.Data.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_Permission");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("WebApplication.Data.Pregnancy", b =>
                {
                    b.Property<int>("PregnancyID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("LMD");

                    b.Property<int>("MotherID");

                    b.Property<int>("PregNo");

                    b.HasKey("PregnancyID");

                    b.HasIndex("MotherID");

                    b.ToTable("Pregnancy");
                });

            modelBuilder.Entity("WebApplication.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApplication.Data.RolePermission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("PermissionId");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("WebApplication.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication.Data.UserPermission", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("PermissionId");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("WebApplication.Data.VacDone", b =>
                {
                    b.Property<int>("VacDoneID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChildID");

                    b.Property<int>("MotherID");

                    b.HasKey("VacDoneID");

                    b.HasIndex("ChildID");

                    b.HasIndex("MotherID");

                    b.ToTable("VacDone");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("WebApplication.Data.Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WebApplication.Data.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WebApplication.Data.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.HasOne("WebApplication.Data.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.Data.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.CheckupsDone", b =>
                {
                    b.HasOne("WebApplication.Data.Mother", "Mother")
                        .WithMany("CheckupsDones")
                        .HasForeignKey("MotherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.Child", b =>
                {
                    b.HasOne("WebApplication.Data.Mother", "Mother")
                        .WithMany("Childs")
                        .HasForeignKey("MotherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.MotherExamination", b =>
                {
                    b.HasOne("WebApplication.Data.Mother", "Mother")
                        .WithMany("Examinations")
                        .HasForeignKey("MotherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.Pregnancy", b =>
                {
                    b.HasOne("WebApplication.Data.Mother", "Mother")
                        .WithMany("Pregnancies")
                        .HasForeignKey("MotherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.RolePermission", b =>
                {
                    b.HasOne("WebApplication.Data.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.Data.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.UserPermission", b =>
                {
                    b.HasOne("WebApplication.Data.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.Data.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.Data.VacDone", b =>
                {
                    b.HasOne("WebApplication.Data.Child")
                        .WithMany("VacDones")
                        .HasForeignKey("ChildID");

                    b.HasOne("WebApplication.Data.Mother", "Mother")
                        .WithMany("VacDones")
                        .HasForeignKey("MotherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
