using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightAPI.Models;

public partial class FlightDatabaseContext : DbContext
{
    public FlightDatabaseContext()
    {
    }

    public FlightDatabaseContext(DbContextOptions<FlightDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<CurrentFlight> CurrentFlights { get; set; }

    public virtual DbSet<FlightBooking> FlightBookings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EVDOJPLN\\SQLEXPRESS01;Database=FlightDatabase;Trusted_Connection=True; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.FullName).HasName("PK__Contactu__C8B4CE9E6FF3D9B4");

            entity.Property(e => e.FullName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Contact)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("message");
        });

        modelBuilder.Entity<CurrentFlight>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__CurrentF__73951ACD43D49CD5");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.FlightClass)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlightFrom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FlightTo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<FlightBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__FlightBo__3213E83FB9340DD9");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingId");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrivalDate");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.DepartureDate).HasColumnName("departureDate");
            entity.Property(e => e.FlightClass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("flightClass");
            entity.Property(e => e.FlightFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("flightFrom");
            entity.Property(e => e.FlightTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("flightTo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__Users__66DCF95D66D458EC");

            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
