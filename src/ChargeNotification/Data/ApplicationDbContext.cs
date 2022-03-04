using ChargeNotification.Models;
using Microsoft.EntityFrameworkCore;

namespace ChargeNotification.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<GameCharge>? GameCharges { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }
}
