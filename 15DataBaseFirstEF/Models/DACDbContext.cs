﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _15DataBaseFirstEF.Models
{
    public partial class DACDbContext : DbContext
    {
        public DACDbContext()
        {
        }

        public DACDbContext(DbContextOptions<DACDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid);

                entity.ToTable("Employee");

                entity.Property(e => e.Eid).HasColumnName("EId");

                entity.Property(e => e.Eaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EAddress");

                entity.Property(e => e.Ename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EName");

                entity.Property(e => e.Esalary).HasColumnName("ESalary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}