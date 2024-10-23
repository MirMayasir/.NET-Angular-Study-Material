using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngularDemo.Models;

public partial class MayasirContext : DbContext
{
    public MayasirContext()
    {
    }

    public MayasirContext(DbContextOptions<MayasirContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Depertment> Depertments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EVDOJPLN\\SQLEXPRESS01;Database=mayasir;Trusted_Connection=True; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.FullName).HasName("PK__Contactu__C8B4CE9E092C1B8B");

            entity.Property(e => e.FullName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Contact)
                .HasMaxLength(10)
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

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__customer__D837D05FAEAB0FB6");

            entity.ToTable("customer");

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("cid");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.Dname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dname");
        });

        modelBuilder.Entity<Depertment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Depertment");

            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Did).HasColumnName("did");
            entity.Property(e => e.Dname)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__employee__D9509F6DB8B93405");

            entity.ToTable("employee");

            entity.Property(e => e.Eid)
                .ValueGeneratedNever()
                .HasColumnName("eid");
            entity.Property(e => e.Ename)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ename");
            entity.Property(e => e.Esalary)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("esalary");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__0809337DA41BE886");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderID");
            entity.Property(e => e.EmpId).HasColumnName("empID");
            entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");
            entity.Property(e => e.Orderdisc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("orderdisc");

            entity.HasOne(d => d.Emp).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__orders__empID__4BAC3F29");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__Users__66DCF95D6D9F2FD9");

            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
