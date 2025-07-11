using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nvk_2310900046_de06.Models;

public partial class NguyenVanKhai2310900046De06Context : DbContext
{
    public NguyenVanKhai2310900046De06Context()
    {
    }

    public NguyenVanKhai2310900046De06Context(DbContextOptions<NguyenVanKhai2310900046De06Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NvkStudent> NvkStudents { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-AJCKN9T\\SQLEXPRESS;Database=NguyenVanKhai_2310900046_de06;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NvkStudent>(entity =>
        {
            entity.HasKey(e => e.NvkStudId).HasName("PK__NvkStude__A0C2E11735983626");

            entity.ToTable("NvkStudent");

            entity.Property(e => e.NvkStudId)
                .ValueGeneratedNever()
                .HasColumnName("nvkStudId");
            entity.Property(e => e.NvkEmail)
                .HasMaxLength(100)
                .HasColumnName("nvkEmail");
            entity.Property(e => e.NvkStudAge).HasColumnName("nvkStudAge");
            entity.Property(e => e.NvkStudGender)
                .HasMaxLength(10)
                .HasColumnName("nvkStudGender");
            entity.Property(e => e.NvkStudName)
                .HasMaxLength(100)
                .HasColumnName("nvkStudName");
            entity.Property(e => e.NvkStudStatus).HasColumnName("nvkStudStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
