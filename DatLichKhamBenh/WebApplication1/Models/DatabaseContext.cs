using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bacsi> Bacsis { get; set; }

    public virtual DbSet<Benhnhan> Benhnhans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lichkham> Lichkhams { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bacsi>(entity =>
        {
            entity.HasKey(e => e.Mabs);

            entity.ToTable("bacsi");

            entity.Property(e => e.Mabs).HasColumnName("mabs");
            entity.Property(e => e.Makhoa).HasColumnName("makhoa");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("date")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Tenbs)
                .HasMaxLength(80)
                .HasColumnName("tenbs");

            entity.HasOne(d => d.Khoa).WithMany(p => p.Bacsis)
                .HasForeignKey(d => d.Makhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bacsi_khoa");
        });

        modelBuilder.Entity<Benhnhan>(entity =>
        {
            entity.HasKey(e => e.Mabn);

            entity.ToTable("benhnhan");

            entity.Property(e => e.Mabn).HasColumnName("mabn");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(50)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("date")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Tenbn)
                .HasMaxLength(80)
                .HasColumnName("tenbn");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Benhnhans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_benhnhan_user");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Makhoa);

            entity.ToTable("khoa");

            entity.Property(e => e.Makhoa).HasColumnName("makhoa");
            entity.Property(e => e.Tenkhoa)
                .HasMaxLength(50)
                .HasColumnName("tenkhoa");
        });

        modelBuilder.Entity<Lichkham>(entity =>
        {
            entity.ToTable("lichkham");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mabn).HasColumnName("mabn");
            entity.Property(e => e.Mabs).HasColumnName("mabs");
            entity.Property(e => e.Ngaykham)
                .HasColumnType("date")
                .HasColumnName("ngaykham");
            entity.Property(e => e.Noidung)
                .HasColumnType("text")
                .HasColumnName("noidung");

            entity.HasOne(d => d.Bennhan).WithMany(p => p.Lichkhams)
                .HasForeignKey(d => d.Mabn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lichkham_benhnhan");

            entity.HasOne(d => d.Bacsi).WithMany(p => p.Lichkhams)
                .HasForeignKey(d => d.Mabs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lichkham_bacsi");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(80)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
