// <auto-generated />
using System;
using Labote.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labote.Core.Migrations
{
    [DbContext(typeof(LaboteContext))]
    [Migration("20220718201143_phoneconfirm")]
    partial class phoneconfirm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labote.Core.Entities.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CargoDriverUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CargoSendType")
                        .HasColumnType("int");

                    b.Property<Guid>("CargoSenderUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CargoStatusType")
                        .HasColumnType("int");

                    b.Property<int>("CargoType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DelyveryDelayDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelayDate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOneDirectory")
                        .HasColumnType("bit");

                    b.Property<string>("OrdererName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RecieverAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecieverDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecieverLatitude")
                        .HasColumnType("bigint");

                    b.Property<long>("RecieverLongitude")
                        .HasColumnType("bigint");

                    b.Property<string>("RecieverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SenderLatitude")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderLongitude")
                        .HasColumnType("bigint");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VehicleTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CargoDriverUserId");

                    b.HasIndex("CargoSenderUserId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Labote.Core.Entities.CargoDriverUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("LaboteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LaboteUserId");

                    b.ToTable("CargoDriverUsers");
                });

            modelBuilder.Entity("Labote.Core.Entities.CargoSenderUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("LaboteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LaboteUserId");

                    b.ToTable("CargoSenderUsers");
                });

            modelBuilder.Entity("Labote.Core.Entities.LaboteUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("NotDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneConfirmCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("UserTopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserTopicId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Labote.Core.Entities.MenuModule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IconName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainPage")
                        .HasColumnType("bit");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MenuModules");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Addres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("LaboteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Langitude")
                        .HasColumnType("bigint");

                    b.Property<long>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LaboteUserId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserMenuModule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MenuModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MenuModelId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserMenuModules");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("NotDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UserTopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UserTopicId");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserTopic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserTopics");
                });

            modelBuilder.Entity("Labote.Core.Entities.VehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<double>("KmPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Labote.Core.Entities.Cargo", b =>
                {
                    b.HasOne("Labote.Core.Entities.CargoDriverUser", "CargoDriverUser")
                        .WithMany("Cargo")
                        .HasForeignKey("CargoDriverUserId");

                    b.HasOne("Labote.Core.Entities.CargoSenderUser", "CargoSenderUser")
                        .WithMany("Cargo")
                        .HasForeignKey("CargoSenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labote.Core.Entities.VehicleType", "VehicleType")
                        .WithMany("Cargos")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoDriverUser");

                    b.Navigation("CargoSenderUser");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Labote.Core.Entities.CargoDriverUser", b =>
                {
                    b.HasOne("Labote.Core.Entities.LaboteUser", "LaboteUser")
                        .WithMany("CargoDriverUsers")
                        .HasForeignKey("LaboteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaboteUser");
                });

            modelBuilder.Entity("Labote.Core.Entities.CargoSenderUser", b =>
                {
                    b.HasOne("Labote.Core.Entities.LaboteUser", "LaboteUser")
                        .WithMany("CargoSenderUser")
                        .HasForeignKey("LaboteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaboteUser");
                });

            modelBuilder.Entity("Labote.Core.Entities.LaboteUser", b =>
                {
                    b.HasOne("Labote.Core.Entities.UserTopic", "UserTopic")
                        .WithMany("LaboteUsers")
                        .HasForeignKey("UserTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTopic");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserAddress", b =>
                {
                    b.HasOne("Labote.Core.Entities.LaboteUser", "LaboteUser")
                        .WithMany("UserAddresses")
                        .HasForeignKey("LaboteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaboteUser");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserMenuModule", b =>
                {
                    b.HasOne("Labote.Core.Entities.MenuModule", "MenuModel")
                        .WithMany("UserMenuModules")
                        .HasForeignKey("MenuModelId");

                    b.HasOne("Labote.Core.Entities.UserRole", "UserRole")
                        .WithMany("UserMenuModules")
                        .HasForeignKey("UserRoleId");

                    b.Navigation("MenuModel");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserRole", b =>
                {
                    b.HasOne("Labote.Core.Entities.UserTopic", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserTopicId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Labote.Core.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Labote.Core.Entities.LaboteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Labote.Core.Entities.LaboteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Labote.Core.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labote.Core.Entities.LaboteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Labote.Core.Entities.LaboteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labote.Core.Entities.CargoDriverUser", b =>
                {
                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("Labote.Core.Entities.CargoSenderUser", b =>
                {
                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("Labote.Core.Entities.LaboteUser", b =>
                {
                    b.Navigation("CargoDriverUsers");

                    b.Navigation("CargoSenderUser");

                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("Labote.Core.Entities.MenuModule", b =>
                {
                    b.Navigation("UserMenuModules");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserRole", b =>
                {
                    b.Navigation("UserMenuModules");
                });

            modelBuilder.Entity("Labote.Core.Entities.UserTopic", b =>
                {
                    b.Navigation("LaboteUsers");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Labote.Core.Entities.VehicleType", b =>
                {
                    b.Navigation("Cargos");
                });
#pragma warning restore 612, 618
        }
    }
}
