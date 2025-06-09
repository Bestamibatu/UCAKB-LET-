using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UCAKBİLETİ.Models;

#nullable disable

namespace UCAKBİLETİ.Migrations
{
    [DbContext(typeof(CustomerDBContext))]
    partial class CustomerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0"); // Versiyon burada EF'ye göre değişebilir

            modelBuilder.Entity("UCAKBİLETİ.Models.Customer", b =>
            {
                b.Property<int>("CustomerID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<string>("CustomerName")
                    .HasColumnType("text");

                b.Property<string>("CustomerSurname")
                    .HasColumnType("text");

                b.Property<string>("Email")
                    .HasColumnType("text");

                b.Property<string>("Password")
                    .HasColumnType("text");

                b.HasKey("CustomerID");

                b.ToTable("customers");
            });

            modelBuilder.Entity("UCAKBİLETİ.Models.Flight", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<string>("FromCity")
                    .HasColumnType("text");

                b.Property<int>("Quota")
                    .HasColumnType("integer");

                b.Property<string>("ToCity")
                    .HasColumnType("text");

                b.Property<DateTime>("DepartureTime")
                    .HasColumnType("timestamp without time zone");

                b.HasKey("Id");

                b.ToTable("flights");
            });

            modelBuilder.Entity("UCAKBİLETİ.Models.Reservation", b =>
            {
                b.Property<int>("CustomerID")
                    .HasColumnType("integer");

                b.Property<int>("FlightID")
                    .HasColumnType("integer");

                b.Property<DateTime>("DataTime")
                    .HasColumnType("timestamp without time zone");

                b.Property<int>("Piece")
                    .HasColumnType("integer");

                b.HasKey("CustomerID", "FlightID");

                b.HasIndex("FlightID");

                b.ToTable("reservations");
            });

            modelBuilder.Entity("UCAKBİLETİ.Models.Reservation", b =>
            {
                b.HasOne("UCAKBİLETİ.Models.Customer", "Customer")
                    .WithMany()
                    .HasForeignKey("CustomerID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("UCAKBİLETİ.Models.Flight", "Flight")
                    .WithMany()
                    .HasForeignKey("FlightID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Customer");
                b.Navigation("Flight");
            });
        }
    }
}
