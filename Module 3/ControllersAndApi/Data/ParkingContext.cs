using Microsoft.EntityFrameworkCore;

namespace ControllersAndApi.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ParkingLot> ParkingLots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Booking>()
                .HasOne(m => m.ParkingLot);
        }
    }
}