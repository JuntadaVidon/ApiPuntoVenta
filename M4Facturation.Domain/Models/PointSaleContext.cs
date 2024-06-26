namespace M4Facturation.Domain.Models;

public partial class PointSaleContext : DbContext
{
    public PointSaleContext(DbContextOptions<PointSaleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Sales> Sales { get; set; }

    public virtual DbSet<SalesDetails> SalesDetails { get; set; }

    public virtual DbSet<Suppliers> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0756EF6BA8");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FecBaja).HasColumnType("datetime");
            entity.Property(e => e.FecIng).HasColumnType("datetime");
            entity.Property(e => e.FecMod).HasColumnType("datetime");
            entity.Property(e => e.UserBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserIng)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserMod)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07964F8AD2");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FecBaja).HasColumnType("datetime");
            entity.Property(e => e.FecIng).HasColumnType("datetime");
            entity.Property(e => e.FecMod).HasColumnType("datetime");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserIng)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserMod)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07E548FACA");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.FecBaja).HasColumnType("datetime");
            entity.Property(e => e.FecIng).HasColumnType("datetime");
            entity.Property(e => e.FecMod).HasColumnType("datetime");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserIng)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserMod)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__29572725");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Products__Suppli__2A4B4B5E");
        });

        modelBuilder.Entity<Sales>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3214EC07C7A77F67");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FecBaja).HasColumnType("datetime");
            entity.Property(e => e.FecIng).HasColumnType("datetime");
            entity.Property(e => e.FecMod).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserIng)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserMod)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sales__CustomerI__2F10007B");
        });

        modelBuilder.Entity<SalesDetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalesDet__3214EC073B6863C1");

            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FecBaja).HasColumnType("datetime");
            entity.Property(e => e.FecIng).HasColumnType("datetime");
            entity.Property(e => e.FecMod).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserIng)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserMod)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SalesDeta__Produ__32E0915F");

            entity.HasOne(d => d.Sale).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SalesDeta__SaleI__31EC6D26");
        });

        modelBuilder.Entity<Suppliers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07198CBCE9");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FecBaja).HasColumnType("datetime");
            entity.Property(e => e.FecIng).HasColumnType("datetime");
            entity.Property(e => e.FecMod).HasColumnType("datetime");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserIng)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserMod)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
