using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=LTIN491094\\SQLSERVER19;Initial Catalog=TenantManagementDB;Integrated Security=True; TrustServerCertificate=True");
    }

    public DbSet<Tenant> Tenants { get; set; }
    //public DbSet<Property> Properties { get; set; }
    public DbSet<RentalApplication> RentalApplications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.Property(e => e.Username) // Primary key for Tenant
             .IsRequired()
            .HasMaxLength(40)
            .HasAnnotation("MinLength", 3)
            .HasAnnotation("RegularExpression", "^[A-Za-z0-9]+$")
            .HasAnnotation("ErrorMessage", "Username should contain only alphabets, numbers")
            .HasAnnotation("Display", "Username")
            .HasAnnotation("ErrorMessage", "Username can't be empty or null")
            .HasAnnotation("StringLength", "Username should be between 3 and 40 characters long");
        });
        base.OnModelCreating(modelBuilder);
    }
}