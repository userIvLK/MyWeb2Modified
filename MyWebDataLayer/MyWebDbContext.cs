using Microsoft.EntityFrameworkCore;
using MyWebDataLayer.DataModels;

namespace MyWebDataLayer;

public partial class MyWebDbContext : DbContext
{
    public MyWebDbContext()
    {
    }

    public MyWebDbContext(DbContextOptions<MyWebDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PurchasePrice> PurchasePrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LENOVO-PC;Initial Catalog=MyWebDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Items__3214EC07DF7B4314");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07222775A2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Customer)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Orderdate).HasColumnType("date");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC0711241275");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("numeric(5, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__ItemI__3C69FB99");

            entity.HasOne(d => d.Oder).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__OderI__3B75D760");
        });

        modelBuilder.Entity<PurchasePrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC0709F3A3AF");

            entity.ToTable("PurchasePrice");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PriceDate).HasColumnType("date");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchasePrices)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseP__ItemI__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
