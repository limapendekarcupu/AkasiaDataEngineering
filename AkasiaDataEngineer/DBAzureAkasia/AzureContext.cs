using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AkasiaDataEngineer.DBAzureAkasia;

public partial class AzureContext : DbContext
{
    public AzureContext()
    {
    }

    public AzureContext(DbContextOptions<AzureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrentPosition> CurrentPositions { get; set; }

    public virtual DbSet<TEmployee> TEmployees { get; set; }

    public virtual DbSet<TPoshistory> TPoshistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=nyarikos.xyz;Port=5432;User Id=postgres;Password=12345;Database=azure;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrentPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("current_position");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(10)
                .HasColumnName("employeeid");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Postitle)
                .HasMaxLength(100)
                .HasColumnName("postitle");
        });

        modelBuilder.Entity<TEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employee_pkey");

            entity.ToTable("t_employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(10)
                .HasColumnName("employeeid");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
        });

        modelBuilder.Entity<TPoshistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PositionHistory_pkey");

            entity.ToTable("t_poshistory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(10)
                .HasColumnName("employeeid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Posid)
                .HasMaxLength(10)
                .HasColumnName("posid");
            entity.Property(e => e.Postitle)
                .HasMaxLength(100)
                .HasColumnName("postitle");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
