using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MySQLwebAPI.Model;

public partial class WiprodbContext : DbContext
{
    public WiprodbContext()
    {
    }

    public WiprodbContext(DbContextOptions<WiprodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1; port=3306;uid=root;pwd=Mayasir123;database=wiprodb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.Ename)
                .HasMaxLength(20)
                .HasColumnName("ename");
            entity.Property(e => e.Esalary)
                .HasMaxLength(20)
                .HasColumnName("esalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
