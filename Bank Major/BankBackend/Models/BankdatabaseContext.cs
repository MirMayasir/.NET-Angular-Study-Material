using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankBackend.Models;

public partial class BankdatabaseContext : DbContext
{
    public BankdatabaseContext()
    {
    }

    public BankdatabaseContext(DbContextOptions<BankdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EVDOJPLN\\SQLEXPRESS01;Database=bankdatabase;Trusted_Connection=True; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountDetail>(entity =>
        {
            entity.HasKey(e => e.Anumber);

            entity.Property(e => e.Anumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Aaddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Abalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Aname)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transactions");

            entity.Property(e => e.Tammount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Tanumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TAnumber");
            entity.Property(e => e.Tnumber)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
