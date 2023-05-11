//using System;
//using System.Collections.Generic;
//using Data.Implementation.DTO;
//using Microsoft.EntityFrameworkCore;

//namespace Data.Models;

//public partial class ShopContext : DbContext
//{
//    public ShopContext()
//    {
//    }

//    public ShopContext(DbContextOptions<ShopContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Event> Events { get; set; }

//    public virtual DbSet<Product> Products { get; set; }

//    public virtual DbSet<State> States { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=shop;Integrated Security=True;TrustServerCertificate=true");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Event>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Events__3213E83F2BDCCE5F");

//            entity.Property(e => e.Id)
//                .ValueGeneratedNever()
//                .HasColumnName("id");
//            entity.Property(e => e.OccurrenceDate)
//                .HasColumnType("date")
//                .HasColumnName("occurrenceDate");
//            entity.Property(e => e.StateId).HasColumnName("stateId");
//            entity.Property(e => e.UserId).HasColumnName("userId");

//            entity.HasOne(d => d.State).WithMany(p => p.Events)
//                .HasForeignKey(d => d.StateId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Events_States");

//            entity.HasOne(d => d.User).WithMany(p => p.Events)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Events_Users");
//        });

//        modelBuilder.Entity<Product>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F80E46A65");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.Name)
//                .HasMaxLength(255)
//                .IsUnicode(false)
//                .HasColumnName("name");
//            entity.Property(e => e.Pegi).HasColumnName("pegi");
//            entity.Property(e => e.Price)
//                .HasColumnType("decimal(18, 0)")
//                .HasColumnName("price");
//        });

//        modelBuilder.Entity<State>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__States__3213E83F78904DA7");

//            entity.Property(e => e.Id)
//                .ValueGeneratedNever()
//                .HasColumnName("id");
//            entity.Property(e => e.ProductId).HasColumnName("productId");
//            entity.Property(e => e.ProductQuantity).HasColumnName("productQuantity");

//            entity.HasOne(d => d.Product).WithMany(p => p.States)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_States_Products");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FCD75E293");

//            entity.Property(e => e.Id)
//                .ValueGeneratedNever()
//                .HasColumnName("id");
//            entity.Property(e => e.Balance)
//                .HasColumnType("decimal(18, 0)")
//                .HasColumnName("balance");
//            entity.Property(e => e.DateOfBirth)
//                .HasColumnType("date")
//                .HasColumnName("dateOfBirth");
//            entity.Property(e => e.Email)
//                .HasMaxLength(255)
//                .IsUnicode(false)
//                .HasColumnName("email");
//            entity.Property(e => e.Nickname)
//                .HasMaxLength(255)
//                .IsUnicode(false)
//                .HasColumnName("nickname");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
