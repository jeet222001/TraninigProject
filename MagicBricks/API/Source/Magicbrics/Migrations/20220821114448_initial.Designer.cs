﻿// <auto-generated />
using System;
using Magicbrics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Magicbrics.Migrations
{
    [DbContext(typeof(magicbrics2392jeetContext))]
    [Migration("20220821114448_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Magicbrics.Models.ApplicationObject", b =>
                {
                    b.Property<int>("AppObjid")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("AppObjid")
                        .HasName("pk_appobjID");

                    b.ToTable("ApplicationObject");
                });

            modelBuilder.Entity("Magicbrics.Models.ApplicationObjectType", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.Property<int?>("AppObjid")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TypeId")
                        .HasName("pk_typeID");

                    b.HasIndex("AppObjid");

                    b.ToTable("ApplicationObjectType");
                });

            modelBuilder.Entity("Magicbrics.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<int?>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("StateID");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Magicbrics.Models.ContactOwner", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Otpno")
                        .HasColumnType("int")
                        .HasColumnName("OTPNo");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<int?>("PrpertyId")
                        .HasColumnType("int")
                        .HasColumnName("PrpertyID");

                    b.HasKey("Id");

                    b.HasIndex("PrpertyId");

                    b.ToTable("ContactOwner");
                });

            modelBuilder.Entity("Magicbrics.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<int?>("Phonecode")
                        .HasColumnType("int")
                        .HasColumnName("phonecode");

                    b.Property<string>("Shortname")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .HasColumnName("shortname")
                        .IsFixedLength(true);

                    b.HasKey("CountryId");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Magicbrics.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("ImageID");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ImageURL");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int")
                        .HasColumnName("PropertyID");

                    b.HasKey("ImageId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Magicbrics.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("LocationID");

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    b.Property<int?>("Pincode")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int")
                        .HasColumnName("PropertyID");

                    b.HasKey("LocationId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Magicbrics.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("int")
                        .HasColumnName("PropertyID");

                    b.Property<string>("Bedroom")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<int?>("BrsId")
                        .HasColumnType("int")
                        .HasColumnName("BRS_ID");

                    b.Property<decimal?>("DepositeAmount")
                        .HasColumnType("money");

                    b.Property<int?>("FacingId")
                        .HasColumnType("int")
                        .HasColumnName("Facing_ID");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<string>("PropertyDescription")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("PropertyTypeId")
                        .HasColumnType("int")
                        .HasColumnName("PropertyTypeID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("PropertyId");

                    b.HasIndex("BrsId");

                    b.HasIndex("FacingId");

                    b.HasIndex("PropertyTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Magicbrics.Models.PropertyFacility", b =>
                {
                    b.Property<int>("FacilityId")
                        .HasColumnType("int")
                        .HasColumnName("FacilityID");

                    b.Property<bool?>("Ac")
                        .HasColumnType("bit")
                        .HasColumnName("AC");

                    b.Property<int?>("BgcId")
                        .HasColumnType("int")
                        .HasColumnName("BGC_ID");

                    b.Property<bool?>("ElectricCharge")
                        .HasColumnType("bit");

                    b.Property<bool?>("Food")
                        .HasColumnType("bit");

                    b.Property<bool?>("Laundry")
                        .HasColumnType("bit");

                    b.Property<bool?>("Lift")
                        .HasColumnType("bit");

                    b.Property<int?>("NoticePeriodMonth")
                        .HasColumnType("int");

                    b.Property<bool?>("PowerBackup")
                        .HasColumnType("bit");

                    b.Property<int?>("PreferredTenants")
                        .HasColumnType("int")
                        .HasColumnName("Preferred_Tenants");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int")
                        .HasColumnName("PropertyID");

                    b.Property<int?>("SharingId")
                        .HasColumnType("int")
                        .HasColumnName("Sharing_ID");

                    b.Property<bool?>("SundayMeal")
                        .HasColumnType("bit")
                        .HasColumnName("Sunday_Meal");

                    b.Property<bool?>("Wifi")
                        .HasColumnType("bit")
                        .HasColumnName("WIFI");

                    b.HasKey("FacilityId")
                        .HasName("pk_Propfaci");

                    b.HasIndex("BgcId");

                    b.HasIndex("PreferredTenants");

                    b.HasIndex("PropertyId");

                    b.HasIndex("SharingId");

                    b.ToTable("PropertyFacility");
                });

            modelBuilder.Entity("Magicbrics.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("StateID");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("states");
                });

            modelBuilder.Entity("Magicbrics.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateReg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("Date_Reg")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .HasMaxLength(254)
                        .IsUnicode(false)
                        .HasColumnType("varchar(254)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Otpno")
                        .HasColumnType("int")
                        .HasColumnName("OTPNo");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Magicbrics.Models.ApplicationObjectType", b =>
                {
                    b.HasOne("Magicbrics.Models.ApplicationObject", "AppObj")
                        .WithMany("ApplicationObjectTypes")
                        .HasForeignKey("AppObjid")
                        .HasConstraintName("fk_appobjID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AppObj");
                });

            modelBuilder.Entity("Magicbrics.Models.City", b =>
                {
                    b.HasOne("Magicbrics.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .HasConstraintName("fk_city");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Magicbrics.Models.ContactOwner", b =>
                {
                    b.HasOne("Magicbrics.Models.Property", "Prperty")
                        .WithMany("ContactOwners")
                        .HasForeignKey("PrpertyId")
                        .HasConstraintName("fk_PropContID");

                    b.Navigation("Prperty");
                });

            modelBuilder.Entity("Magicbrics.Models.Image", b =>
                {
                    b.HasOne("Magicbrics.Models.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("fk_PropImg");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Magicbrics.Models.Location", b =>
                {
                    b.HasOne("Magicbrics.Models.Property", "Property")
                        .WithMany("Locations")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("fk_PropLoc");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Magicbrics.Models.Property", b =>
                {
                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "Brs")
                        .WithMany("PropertyBrs")
                        .HasForeignKey("BrsId")
                        .HasConstraintName("fk_PropObjTID");

                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "Facing")
                        .WithMany("PropertyFacings")
                        .HasForeignKey("FacingId")
                        .HasConstraintName("fk_Facing");

                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "PropertyType")
                        .WithMany("PropertyPropertyTypes")
                        .HasForeignKey("PropertyTypeId")
                        .HasConstraintName("fk_PropType");

                    b.HasOne("Magicbrics.Models.User", "User")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_userProp");

                    b.Navigation("Brs");

                    b.Navigation("Facing");

                    b.Navigation("PropertyType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Magicbrics.Models.PropertyFacility", b =>
                {
                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "Bgc")
                        .WithMany("PropertyFacilityBgcs")
                        .HasForeignKey("BgcId")
                        .HasConstraintName("fk_bgc");

                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "PreferredTenantsNavigation")
                        .WithMany("PropertyFacilityPreferredTenantsNavigations")
                        .HasForeignKey("PreferredTenants")
                        .HasConstraintName("fk_tenant");

                    b.HasOne("Magicbrics.Models.Property", "Property")
                        .WithMany("PropertyFacilities")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("fk_PropID");

                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "Sharing")
                        .WithMany("PropertyFacilitySharings")
                        .HasForeignKey("SharingId")
                        .HasConstraintName("fk_Shar");

                    b.Navigation("Bgc");

                    b.Navigation("PreferredTenantsNavigation");

                    b.Navigation("Property");

                    b.Navigation("Sharing");
                });

            modelBuilder.Entity("Magicbrics.Models.State", b =>
                {
                    b.HasOne("Magicbrics.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("fk_country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Magicbrics.Models.User", b =>
                {
                    b.HasOne("Magicbrics.Models.ApplicationObjectType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .HasConstraintName("fk_userTypeID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Magicbrics.Models.ApplicationObject", b =>
                {
                    b.Navigation("ApplicationObjectTypes");
                });

            modelBuilder.Entity("Magicbrics.Models.ApplicationObjectType", b =>
                {
                    b.Navigation("PropertyBrs");

                    b.Navigation("PropertyFacilityBgcs");

                    b.Navigation("PropertyFacilityPreferredTenantsNavigations");

                    b.Navigation("PropertyFacilitySharings");

                    b.Navigation("PropertyFacings");

                    b.Navigation("PropertyPropertyTypes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Magicbrics.Models.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Magicbrics.Models.Property", b =>
                {
                    b.Navigation("ContactOwners");

                    b.Navigation("Images");

                    b.Navigation("Locations");

                    b.Navigation("PropertyFacilities");
                });

            modelBuilder.Entity("Magicbrics.Models.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Magicbrics.Models.User", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}