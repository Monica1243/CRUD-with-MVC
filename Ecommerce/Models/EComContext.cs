using System;
using System.Collections.Generic;
using Ecommerce.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class EComContext : DbContext
{
    public EComContext()
    {
    }

    public EComContext(DbContextOptions<EComContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderSummary> OrderSummaries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<RefundDetail> RefundDetails { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<TaxCalculation> TaxCalculations { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CEI3127\\SQL2022;Database=ECom;User Id=sa;Password=Santa@12;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC27F57AFA38");

            entity.ToTable("Cart");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProductId).HasColumnName("Product ID");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__Product ID__628FA481");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.MembershipType).HasName("PK__Discount__65D16264C60AAFE8");

            entity.Property(e => e.MembershipType).HasColumnName("Membership Type");
            entity.Property(e => e.Discount1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Discount%");
            entity.Property(e => e.ModifiedAt).HasColumnName("Modified At");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order De__81BDAE1E552627B1");

            entity.ToTable("Order Details");

            entity.Property(e => e.OrderId).HasColumnName("Order ID");
            entity.Property(e => e.ModifiedAt).HasColumnName("Modified At");
            entity.Property(e => e.ProductId).HasColumnName("Product ID");
            entity.Property(e => e.ReasonForCancellation)
                .HasColumnType("text")
                .HasColumnName("Reason for Cancellation");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order Det__Produ__5812160E");
        });

        modelBuilder.Entity<OrderSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order Summary");

            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Invoice Amount");
            entity.Property(e => e.ModifiedAt).HasColumnName("Modified At");
            entity.Property(e => e.OrderId).HasColumnName("Order ID");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .HasColumnName("Payment Type");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tax Amount");
            entity.Property(e => e.TotalAmount)
                .HasComputedColumnSql("(([Invoice Amount]+[Tax Amount])-[Discount])", false)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("Total Amount");
            entity.Property(e => e.UserId).HasColumnName("User ID");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order Sum__Order__5EBF139D");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order Sum__User __5FB337D6");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__AF0FD00BD433A4E9");

            entity.Property(e => e.ProductId).HasColumnName("Product ID");
            entity.Property(e => e.AvailableQuantity).HasColumnName("Available Quantity");
            entity.Property(e => e.CategoryId).HasColumnName("Category ID");
            entity.Property(e => e.ModifiedAt).HasColumnName("Modified At");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(50)
                .HasColumnName("Product Description");
            entity.Property(e => e.ProductImage)
                .HasColumnType("text")
                .HasColumnName("Product Image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("Product Name");
            entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__3A81B327");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ProductC__788261CC1D8521BF");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("Category Id");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ModifiedAt).HasColumnName("Modified At");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RefundDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.OrderId).HasColumnName("Order ID");
            entity.Property(e => e.ProductId).HasColumnName("Product ID");
            entity.Property(e => e.RefundAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Refund Amount");
            entity.Property(e => e.RefundStatus)
                .HasMaxLength(50)
                .HasColumnName("Refund Status");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RefundDet__Order__6477ECF3");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.SalesAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Sales Amount");
        });

        modelBuilder.Entity<TaxCalculation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TaxCalculation");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Tax)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tax%");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserDeta__1788CC4C93743731");

            entity.HasIndex(e => e.Phone, "UQ__UserDeta__5C7E359E9BA166E4").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__UserDeta__A9D105349E6DF4BC").IsUnique();

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MembershipType)
                .HasDefaultValue(false)
                .HasColumnName("Membership Type");
            entity.Property(e => e.ModifiedAt).HasColumnName("Modified At");
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("user");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.MembershipTypeNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.MembershipType)
                .HasConstraintName("FK__UserDetai__Membe__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
