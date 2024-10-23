using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScoreManagmentAPI.Models;

public partial class ScoreMonitoringContext : DbContext
{
    public ScoreMonitoringContext()
    {
    }

    public ScoreMonitoringContext(DbContextOptions<ScoreMonitoringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EVDOJPLN\\SQLEXPRESS01;Database=ScoreMonitoring;Trusted_Connection=True; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C8701C9F5799");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EventType).HasMaxLength(50);
            entity.Property(e => e.MatchId).HasColumnName("MatchID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Match).WithMany(p => p.Events)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__MatchID__4E88ABD4");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PK__Match__4218C8373441F6C8");

            entity.ToTable("Match");

            entity.Property(e => e.MatchId).HasColumnName("MatchID");
            entity.Property(e => e.Sport).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Team1).HasMaxLength(100);
            entity.Property(e => e.Team2).HasMaxLength(100);
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__Score__7DD229F1AE10497B");

            entity.ToTable("Score");

            entity.Property(e => e.ScoreId).HasColumnName("ScoreID");
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");
            entity.Property(e => e.MatchId).HasColumnName("MatchID");

            entity.HasOne(d => d.Match).WithMany(p => p.Scores)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Score__MatchID__4BAC3F29");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("PK__Sports__7A41AF1CB74694D2");

            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE7B91BE6AF2F");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SportId).HasColumnName("SportID");

            entity.HasOne(d => d.Sport).WithMany(p => p.Teams)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK__Teams__SportID__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
