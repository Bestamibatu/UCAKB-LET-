using Microsoft.EntityFrameworkCore;

namespace UCAKBİLETİ.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer tablosu
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");
                entity.HasKey(e => e.CustomerID);
                entity.Property(e => e.CustomerID).UseIdentityByDefaultColumn();
                entity.Property(e => e.CustomerName).HasColumnType("text");
                entity.Property(e => e.CustomerSurname).HasColumnType("text");
                entity.Property(e => e.Email).HasColumnType("text");
                entity.Property(e => e.Password).HasColumnType("text");
            });

            // Flight tablosu
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flights");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityByDefaultColumn();
                entity.Property(e => e.DepartureTime).HasColumnType("timestamp without time zone");
                entity.Property(e => e.FromCity).HasColumnType("text");
                entity.Property(e => e.ToCity).HasColumnType("text");
                entity.Property(e => e.Quota).HasColumnType("integer");
            });

            // Reservation tablosu
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");
                entity.HasKey(e => new { e.CustomerID, e.FlightID });
                entity.Property(e => e.CustomerID).HasColumnType("integer");
                entity.Property(e => e.FlightID).HasColumnType("integer");
                entity.Property(e => e.DataTime).HasColumnType("timestamp without time zone");
                entity.Property(e => e.Piece).HasColumnType("integer");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Flight)
                    .WithMany()
                    .HasForeignKey(d => d.FlightID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
