using ChargeNotification.Models;
using Microsoft.EntityFrameworkCore;

namespace ChargeNotification.Data;
public class AppDbContext : DbContext
{
    public DbSet<GameCharge> GameCharges => this.Set<GameCharge>();
    public DbSet<Customer> Customers => this.Set<Customer>();

    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=dbo");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("customer");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("customername");

            entity.Property(e => e.CustomerId).HasColumnName("customernumber");
        });

        modelBuilder.Entity<GameCharge>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("gamecharge");
            entity.Property(e => e.ChargeDate).HasColumnName("chargedate");
            entity.Property(e => e.CustomerId).HasColumnName("customerid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TotalCost).HasColumnName("totalcost");
        });
        // SeedDatabase(modelBuilder);

    }

    private static void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameCharge>().HasData(new GameCharge
        {
            CustomerId = 1,
            Description = "Game 1",
            ChargeableItem = new()
            {
                { "New skin", 5 },
                { "Power Boost", 10 }
            },
            ChargeDate = new()
        });
        modelBuilder.Entity<GameCharge>().HasData(new GameCharge
        {
            CustomerId = 1,
            Description = "Game 2",
            ChargeableItem = new()
            {
                { "Diamond armour", 5 },
                { "Level cheat sheet", 50 }
            },
            ChargeDate = new()
        });

        modelBuilder.Entity<GameCharge>().HasData(new GameCharge
        {
            CustomerId = 1,
            Description = "Game 3",
            ChargeableItem = new()
            {
                { "Level Up", 75 },
            },
            ChargeDate = new()
        });

        modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 1, CustomerName = "Customer 1" });
        modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 2, CustomerName = "Customer 2" });
    }

}
