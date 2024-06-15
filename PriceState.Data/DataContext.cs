using Microsoft.EntityFrameworkCore;
using PriceState.Data.Configurations;
using PriceState.Data.Models;
using PriceState.Data.Reports;

namespace PriceState.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.Migrate();
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    //     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PriceState;Username=postgres;Password=123");

    public DbSet<Organization> Organizations { get; set; }

    public DbSet<PriceOrganization> PriceOrganizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Region> Regions { get; set; }
    public DbSet<Unit> Units { get; set; }

    public DbSet<MailToken> MailToken { get; set; }

    public DbSet<FullProduct> FullProducts { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }

    public DbSet<ProductGroup> ProductGroups { get; set; }

    public DbSet<AvgPrice> AvgPrices { get; set; }

    public DbSet<LastPrice> LastPrices { get; set; }

    public DbSet<Otchet3> Otchet3s { get; set; }

    public DbSet<Otchet5> Otchet5s { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        new MailTokenConfiguration(mb.Entity<MailToken>());
        new UserConfigurations(mb.Entity<User>());
        new OrganizationConfigurations(mb.Entity<Organization>());
        new PriceOrganizationConfigurations(mb.Entity<PriceOrganization>());
        new ProductConfigurations(mb.Entity<Product>());
        new RegionConfigurations(mb.Entity<Region>());
        new UnitConfigurations(mb.Entity<Unit>());
        new FullProductConfigurations(mb.Entity<FullProduct>());
        new ProductTypeConfigurations(mb.Entity<ProductType>());
        new ProductGroupConfigurations(mb.Entity<ProductGroup>());
        base.OnModelCreating(mb);
    }
}