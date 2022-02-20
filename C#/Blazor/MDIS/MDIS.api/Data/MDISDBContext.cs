﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using MDIS.api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MDIS.api.Data
{
    public partial class MDISDBContext : DbContext
    {
        public MDISDBContext()
        {
        }

        public MDISDBContext(DbContextOptions<MDISDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbDrone> TbDrone { get; set; }
        public virtual DbSet<TbFlying> TbFlying { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbDrone>(entity =>
            {
                entity.HasKey(e => e.DroneMid)
                    .HasName("TB_DRONE_pk");

                entity.ToTable("TB_DRONE");

                entity.Property(e => e.DroneMid)
                    .HasColumnName("DRONE_MID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Altitude).HasColumnName("ALTITUDE");

                entity.Property(e => e.AltitudeOpen).HasColumnName("ALTITUDE_OPEN");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("CREATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Direction).HasColumnName("DIRECTION");

                entity.Property(e => e.DroneId)
                    .IsRequired()
                    .HasColumnName("DRONE_ID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DroneType)
                    .IsRequired()
                    .HasColumnName("DRONE_TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HeightType)
                    .IsRequired()
                    .HasColumnName("HEIGHT_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasColumnName("ID_TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Isauth)
                    .HasColumnName("ISAUTH")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Isfaultflying)
                    .HasColumnName("ISFAULTFLYING")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Isuse)
                    .HasColumnName("ISUSE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Isvalid)
                    .IsRequired()
                    .HasColumnName("ISVALID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Latitude).HasColumnName("LATITUDE");

                entity.Property(e => e.LatitudeOpen).HasColumnName("LATITUDE_OPEN");

                entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");

                entity.Property(e => e.LongitudeOpen).HasColumnName("LONGITUDE_OPEN");

                entity.Property(e => e.Postno)
                    .IsRequired()
                    .HasColumnName("POSTNO")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PostnoOpen)
                    .IsRequired()
                    .HasColumnName("POSTNO_OPEN")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnName("STATUS_CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("UPDATE_TIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFlying>(entity =>
            {
                entity.HasKey(e => e.FlyingId)
                    .HasName("TB_FLYING_pk");

                entity.ToTable("TB_FLYING");

                entity.Property(e => e.FlyingId)
                    .HasColumnName("FLYING_ID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CmPostno)
                    .IsRequired()
                    .HasColumnName("CM_POSTNO")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DroneId)
                    .IsRequired()
                    .HasColumnName("DRONE_ID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlyingEndTime)
                    .HasColumnName("FLYING_END_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlyingStartTime)
                    .HasColumnName("FLYING_START_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Postno)
                    .IsRequired()
                    .HasColumnName("POSTNO")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Drone)
                    .WithMany(p => p.TbFlying)
                    .HasForeignKey(d => d.DroneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_OBJECT_TB_FLYING2_HIS_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}