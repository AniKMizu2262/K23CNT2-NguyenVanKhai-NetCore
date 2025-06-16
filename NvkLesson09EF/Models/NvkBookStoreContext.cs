using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NvkLesson09EF.Models;

public partial class NvkBookStoreContext : DbContext
{
    public NvkBookStoreContext()
    {
    }

    public NvkBookStoreContext(DbContextOptions<NvkBookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<OrderBook> OrderBooks { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A6F0D1E72D");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(512);
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Picture)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C207BEA7A063");

            entity.ToTable("Book");

            entity.Property(e => e.BookId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Book__CategoryId__29572725");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK__Book__PublisherI__286302EC");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B748A31B6");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<OrderBook>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderBoo__C3905BCF7CD6C869");

            entity.ToTable("OrderBook");

            entity.Property(e => e.OrderId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasMaxLength(512);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderReceive).HasColumnType("datetime");
            entity.Property(e => e.ReceiveAddress).HasMaxLength(512);
            entity.Property(e => e.ReceivePhone)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.OrderBooks)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__OrderBook__Accou__2E1BDC42");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36CA0568EB8");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.BookId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OrderId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.TotalMoney).HasComputedColumnSql("([Quantity]*[Price])", false);

            entity.HasOne(d => d.Book).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__OrderDeta__BookI__31EC6D26");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__30F848ED");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PK__Publishe__4C657FAB14798B8F");

            entity.ToTable("Publisher");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PublisherName).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
