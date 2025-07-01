using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nvk_Lesson11.Models;

public partial class NguyenVanKhai2310900046Context : DbContext
{
    public NguyenVanKhai2310900046Context()
    {
    }

    public NguyenVanKhai2310900046Context(DbContextOptions<NguyenVanKhai2310900046Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NvkEmployee> NvkEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-AJCKN9T\\SQLEXPRESS;Database=NguyenVanKhai_2310900046;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NvkEmployee>(entity =>
        {
            entity.HasKey(e => e.NvkEmpId).HasName("PK__NvkEmplo__67D685BFD2772B42");

            entity.ToTable("NvkEmployee");

            entity.Property(e => e.NvkEmpId).HasColumnName("nvkEmpId");
            entity.Property(e => e.NvkEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("nvkEmpLevel");
            entity.Property(e => e.NvkEmpName)
                .HasMaxLength(100)
                .HasColumnName("nvkEmpName");
            entity.Property(e => e.NvkEmpStartDate).HasColumnName("nvkEmpStartDate");
            entity.Property(e => e.NvkEmpStatus).HasColumnName("nvkEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
