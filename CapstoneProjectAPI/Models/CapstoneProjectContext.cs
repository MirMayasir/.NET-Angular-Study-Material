using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectAPI.Models;

public partial class CapstoneProjectContext : DbContext
{
    public CapstoneProjectContext()
    {
    }

    public CapstoneProjectContext(DbContextOptions<CapstoneProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EVDOJPLN\\SQLEXPRESS01;Database=CapstoneProject;Trusted_Connection=True; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__booking__C6D03BCD9613D934");

            entity.ToTable("booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingId");
            entity.Property(e => e.BookDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("bookDate");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.DosagePeriod).HasColumnName("dosagePeriod");
            entity.Property(e => e.DrugDescription)
                .HasColumnType("text")
                .HasColumnName("drugDescription");
            entity.Property(e => e.DrugName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("drugName");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.DrugId).HasName("PK__Drugs__908D66F6B7B78AF4");

            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__Subscrip__9A2B24BDFA816F68");

            entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");
            entity.Property(e => e.IsSubscribed).HasDefaultValue(true);
            entity.Property(e => e.PlanType).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1A7E428C");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
