﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SenderCoordCore.Models;

namespace SenderCoordCore.Context
{
    public partial class CoordsContext : DbContext
    {
        public CoordsContext()
        {
        }

        public CoordsContext(DbContextOptions<CoordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coords> Coords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coords>(entity =>
            {
                entity.HasKey(e => e.CooRecordId);

                entity.Property(e => e.CooRecordId)
                    .HasColumnName("coo_RecordID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CooImei)
                    .IsRequired()
                    .HasColumnName("coo_imei");

                entity.Property(e => e.CooLatitude)
                    .IsRequired()
                    .HasColumnName("coo_latitude");

                entity.Property(e => e.CooLongitude)
                    .IsRequired()
                    .HasColumnName("coo_longitude");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}