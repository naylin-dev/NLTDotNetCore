﻿using Microsoft.EntityFrameworkCore;

namespace NLTDotNetCore.RealtimeChartApp.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPieChart> TblPieCharts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPieChart>(entity =>
        {
            entity.HasKey(e => e.PieChartId);

            entity.ToTable("Tbl_PieChart");

            entity.Property(e => e.PieChartName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PieChartValue).HasColumnType("decimal(18, 2)");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}