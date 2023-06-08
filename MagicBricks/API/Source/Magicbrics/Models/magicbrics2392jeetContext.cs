using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Magicbrics.Models
{
    public partial class magicbrics2392jeetContext : DbContext
    {
        public magicbrics2392jeetContext()
        {
        }

        public magicbrics2392jeetContext(DbContextOptions<magicbrics2392jeetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationObject> ApplicationObjects { get; set; }
        public virtual DbSet<ApplicationObjectType> ApplicationObjectTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ContactOwner> ContactOwners { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyFacility> PropertyFacilities { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VWgetPropertyType> VWgetPropertyTypes { get; set; }
        public virtual DbSet<VwPropertyDetail> VwPropertyDetails { get; set; }
        public virtual DbSet<VwgpropertyDetail> VwgpropertyDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=43.204.134.14;Database=magicbrics-2392-jeet;User ID=magicbrics-2392-jeet;Password=TAr1bQSweB6NnHt");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationObject>(entity =>
            {
                entity.HasKey(e => e.AppObjid)
                    .HasName("pk_appobjID");

                entity.ToTable("ApplicationObject");

                entity.Property(e => e.ObjectName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationObjectType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("pk_typeID");

                entity.ToTable("ApplicationObjectType");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppObj)
                    .WithMany(p => p.ApplicationObjectTypes)
                    .HasForeignKey(d => d.AppObjid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_appobjID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("CityID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("fk_city");
            });

            modelBuilder.Entity<ContactOwner>(entity =>
            {
                entity.ToTable("ContactOwner");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Otpno).HasColumnName("OTPNo");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PrpertyId).HasColumnName("PrpertyID");

                entity.HasOne(d => d.Prperty)
                    .WithMany(p => p.ContactOwners)
                    .HasForeignKey(d => d.PrpertyId)
                    .HasConstraintName("fk_PropContID");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phonecode).HasColumnName("phonecode");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("shortname")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.HasIndex(e => e.ImageId, "ImgType_fk");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.File)
                    .HasMaxLength(50)
                    .HasColumnName("file");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.HasOne(d => d.ImageType)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ImageTypeId)
                    .HasConstraintName("fk_imgType");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("fk_PropImg");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("fk_PropLoc");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.BrsId).HasColumnName("BRS_ID");

                entity.Property(e => e.PropertyDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeId).HasColumnName("PropertyTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Brs)
                    .WithMany(p => p.PropertyBrs)
                    .HasForeignKey(d => d.BrsId)
                    .HasConstraintName("fk_PropObjTID");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.PropertyPropertyTypes)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .HasConstraintName("fk_PropType");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.Properties)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("fk_userProp");
            });

            modelBuilder.Entity<PropertyFacility>(entity =>
            {
                entity.HasKey(e => e.FacilityId)
                    .HasName("pk_Propfaci");

                entity.ToTable("PropertyFacility");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.Ac).HasColumnName("AC");

                entity.Property(e => e.AgeOfConstruction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AvailableFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BgcId).HasColumnName("BGC_ID");

                entity.Property(e => e.FurnishedStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PossessionStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredTenants).HasColumnName("Preferred_Tenants");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.SharingId).HasColumnName("Sharing_ID");

                entity.Property(e => e.SundayMeal).HasColumnName("Sunday_Meal");

                entity.Property(e => e.TokenAmount).HasColumnType("money");

                entity.Property(e => e.Wifi).HasColumnName("WIFI");

                entity.HasOne(d => d.Bgc)
                    .WithMany(p => p.PropertyFacilityBgcs)
                    .HasForeignKey(d => d.BgcId)
                    .HasConstraintName("fk_bgc");

                entity.HasOne(d => d.PreferredTenantsNavigation)
                    .WithMany(p => p.PropertyFacilityPreferredTenantsNavigations)
                    .HasForeignKey(d => d.PreferredTenants)
                    .HasConstraintName("fk_tenant");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertyFacilities)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("fk_PropID");

                entity.HasOne(d => d.Sharing)
                    .WithMany(p => p.PropertyFacilitySharings)
                    .HasForeignKey(d => d.SharingId)
                    .HasConstraintName("fk_Shar");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("states");

                entity.Property(e => e.StateId)
                    .ValueGeneratedNever()
                    .HasColumnName("StateID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("fk_country");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DateReg)
                    .HasColumnType("date")
                    .HasColumnName("Date_Reg")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Otpno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("OTPNo");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_userTypeID");
            });

            modelBuilder.Entity<VWgetPropertyType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGetPropertyType");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPropertyDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwPropertyDetails");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgeOfConstruction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AvailableFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BgcId).HasColumnName("BGC_ID");

                entity.Property(e => e.BrsId).HasColumnName("BRS_ID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DenseRank).HasColumnName("denseRank");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FurnishedStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Imagename)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PossessionStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PropertyDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.PropertyTypeId).HasColumnName("PropertyTypeID");

                entity.Property(e => e.StateName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TokenAmount).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VwgpropertyDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VWGPropertyDetails");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgeOfConstruction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AvailableFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BgcId).HasColumnName("BGC_ID");

                entity.Property(e => e.BrsId).HasColumnName("BRS_ID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DenseRank).HasColumnName("denseRank");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FurnishedStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Imagename)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PossessionStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PropertyDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.PropertyTypeId).HasColumnName("PropertyTypeID");

                entity.Property(e => e.StateName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TokenAmount).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
