using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using yocar.Districts;
using yocar.Insurance_v1.Entities.ContactPersons;
using yocar.Insurance_v1.Entities.Garages;
using yocar.Insurance_v1.Entities.InsuranceCompanies;
using yocar.Insurance_v1.Entities.Locations;
using yocar.Insurance_v1.Entities.Brands;
using yocar.ProvinceCities;
using yocar.Wards;

namespace yocar.Insurance_v1.Data;

public class Insurance_v1DbContext : AbpDbContext<Insurance_v1DbContext>
{
    public Insurance_v1DbContext(DbContextOptions<Insurance_v1DbContext> options)
        : base(options)
    {
    }
    public DbSet<Ward> Wards { get; set; } = null!;
    public DbSet<District> Districts { get; set; } = null!;
    public DbSet<ProvinceCity> ProvinceCities { get; set; } = null!;
    public DbSet<InsuranceCompany> InsuranceCompanies { get; set; } = null!;
    public DbSet<Garage> Garages { get; set; } = null!;
    public DbSet<ContactPerson> ContactPeople { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        builder.Entity<Ward>(b =>
        {
            b.ToTable("Wards");
            b.HasKey(w => w.Id);
            b.Property(w => w.Name)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(w => w.Description)
             .IsRequired()
             .HasMaxLength(1000);
            b.Property(w => w.Slug)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(w => w.DistrictId)
             .IsRequired();
            b.HasOne<District>()
             .WithMany()
             .HasForeignKey(w => w.DistrictId)
             .OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<ProvinceCity>(b =>
        {
            b.ToTable("ProvinceCities");
            b.HasKey(pc => pc.Id);
            b.Property(pc => pc.Name)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(pc => pc.Slug)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(pc => pc.Description)
             .IsRequired()
             .HasMaxLength(1000);
        });
        builder.Entity<District>(b =>
        {

            b.ToTable("Districts");
            b.ConfigureByConvention();
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            b.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(200);
            b.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);
            b.HasOne<ProvinceCity>()
                .WithMany()
                .HasForeignKey(x => x.ProvinceCityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            b.HasIndex(x => x.Name);
        });
        // InsuranceCompany Configuration
        builder.Entity<InsuranceCompany>(b =>
        {
            b.ToTable("InsuranceCompanies");
            b.HasKey(ic => ic.Id);
            b.Property(ic => ic.Name)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(ic => ic.Description)
             .IsRequired()
             .HasMaxLength(500);
            b.HasMany(ic => ic.Garages)
             .WithOne(g => g.InsuranceCompany)
             .HasForeignKey(g => g.InsuranceCompanyId);
        });


        // Garage Configuration
        builder.Entity<Garage>(b =>
        {
            b.ToTable("Garages");
            b.HasKey(g => g.Id);
            b.Property(g => g.Name)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(g => g.Address)
             .IsRequired()
             .HasMaxLength(500);
            b.Property(g => g.InsuranceCompanyId)
             .IsRequired();
            b.HasOne<InsuranceCompany>()
             .WithMany(ic => ic.Garages)
             .HasForeignKey(g => g.InsuranceCompanyId);
            b.Property(g => g.BrandId)
             .IsRequired(false); // Optional foreign key
            b.HasOne<Brand>()
             .WithMany(b => b.Garages)
             .HasForeignKey(g => g.BrandId)
             .IsRequired(false); // Optional navigation
        });


        // ContactPerson Configuration
        builder.Entity<ContactPerson>(b =>
        {
            b.ToTable("ContactPeople");
            b.HasKey(cp => cp.Id);
            b.Property(cp => cp.Name)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(cp => cp.Email)
             .IsRequired()
             .HasMaxLength(255);
            b.Property(cp => cp.Phone)
             .IsRequired()
             .HasMaxLength(20);
        });

        // Brand Configuration
        builder.Entity<Brand>(b =>
        {
            b.ToTable("Brands");
            b.HasKey(b => b.Id);
            b.Property(b => b.Name)
             .IsRequired()
             .HasMaxLength(255);
        });

        // Location Configuration
        builder.Entity<Location>(b =>
        {
            b.ToTable("Locations");
            b.HasKey(l => l.Id);
            b.Property(l => l.Latitude)
             .IsRequired();
            b.Property(l => l.Longitude)
             .IsRequired();
            b.Property(l => l.Address)
             .IsRequired()
             .HasMaxLength(500);
            b.Property(l => l.WardId)
             .IsRequired();
            b.HasOne<Ward>()
             .WithMany()
             .HasForeignKey(l => l.WardId);
        });

        /* Configure your own entities here */
    }

}
