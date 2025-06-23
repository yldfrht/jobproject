using System;
using System.Collections.Generic;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Context;

public partial class PostgreContext(DbContextOptions<PostgreContext> options) : DbContext(options)
{
    public virtual DbSet<Bran> Brans { get; set; }

    public virtual DbSet<Hastane> Hastanes { get; set; }

    public virtual DbSet<Hastum> Hasta { get; set; }

    public virtual DbSet<Hekim> Hekims { get; set; }

    public virtual DbSet<Randevu> Randevus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;password=Anatolia.23");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brans_pk");

            entity.ToTable("brans");

            entity.HasIndex(e => e.Id, "brans_id_idx");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Adi)
                .HasColumnType("character varying")
                .HasColumnName("adi");
            entity.Property(e => e.Hastaneid).HasColumnName("hastaneid");
        });

        modelBuilder.Entity<Hastane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hastane_pk");

            entity.ToTable("hastane");

            entity.HasIndex(e => e.Id, "hastane_id_idx");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Adi)
                .HasColumnType("character varying")
                .HasColumnName("adi");
        });

        modelBuilder.Entity<Hastum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hasta_pk");

            entity.ToTable("hasta");

            entity.HasIndex(e => e.Id, "hasta_id_idx");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Adsoyad)
                .HasColumnType("character varying")
                .HasColumnName("adsoyad");
            entity.Property(e => e.Kimliknumarasi).HasColumnName("kimliknumarasi");
        });

        modelBuilder.Entity<Hekim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hekim_pk");

            entity.ToTable("hekim");

            entity.HasIndex(e => e.Id, "hekim_id_idx");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AdiSoyadi)
                .HasColumnType("character varying")
                .HasColumnName("adi soyadi");
            entity.Property(e => e.Bransid).HasColumnName("bransid");
            entity.Property(e => e.Hastaneid).HasColumnName("hastaneid");
            entity.Property(e => e.Kimliknumarasi).HasColumnName("kimliknumarasi");
        });

        modelBuilder.Entity<Randevu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("randevu_pk");

            entity.ToTable("randevu");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Hastaid).HasColumnName("hastaid");
            entity.Property(e => e.Hastaneid).HasColumnName("hastaneid");
            entity.Property(e => e.Hekimid).HasColumnName("hekimid");
            entity.Property(e => e.Randevuaciklama)
                .HasColumnType("character varying")
                .HasColumnName("randevuaciklama");
            entity.Property(e => e.Randevuzamani).HasColumnName("randevuzamani");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Randevu)
                .HasForeignKey<Randevu>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randevu_fk_2");

            entity.HasOne(d => d.Id1).WithOne(p => p.Randevu)
                .HasForeignKey<Randevu>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randevu_fk_1");

            entity.HasOne(d => d.Id2).WithOne(p => p.Randevu)
                .HasForeignKey<Randevu>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randevu_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
