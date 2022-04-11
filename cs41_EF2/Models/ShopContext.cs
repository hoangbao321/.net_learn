using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

public class ShopContext : DbContext
{
    public DbSet<Product> products { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<CategoryDetail> categoryDetails { get; set; }

    private string ConnectionString = @"
            Data Source=localhost,1433;
            Initial Catalog = shopData;
            User ID = sa;
            Password= CASter789";

    // khi DBcontext đc tạo mới tạo ra nó sẽ thi hành phương thức Config
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLoggerFactory(loggerFactory);
        optionsBuilder.UseSqlServer(ConnectionString);
        optionsBuilder.UseLazyLoadingProxies();
        Console.WriteLine("On configuring");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Console.WriteLine("OnModelCreating");

        //Fluent API
        modelBuilder.Entity<Product>(entity =>
        {
            //Tạo bảng tên SanPham
            entity.ToTable("SanPham");

            //PK
            entity.HasKey(p => p.ProductID);

            //Index
            // tăng tốc độ tìm kiếm
            entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham-price");

            //Relative
            // Product thuộc tính CategID thì sẽ thuộc 1 loại hàng,
            entity.HasOne(p => p.Category)
                            .WithMany() // Category không có Property chứa tập hợp FK chúng ta tạo ra
                            .HasForeignKey("CateID") // Đặt tên cho khóa ngoại
                            .OnDelete(DeleteBehavior.Cascade) // xóa phần 1 phần nhiều xóa theo
                            .HasConstraintName("khoa_ngoai_Sanpham_category");

            entity.HasOne(p => p.Category2)
                         .WithMany(c => c.Products) //collect navigator
                         .HasForeignKey("CateID2")
                         .OnDelete(DeleteBehavior.NoAction); // Xóa phần 1 phần nhiều không ảnh hưởng gì

            entity.Property(p => p.ProductName)
                  .HasColumnName("Title")
                  .HasMaxLength(60)
                  .IsRequired(true);
        });

        modelBuilder.Entity<CategoryDetail>(entity =>
        {
            entity.HasOne(d => d.category)
                    .WithOne(c => c.categorydetail)
                    .HasForeignKey<CategoryDetail>(c => c.CategoryDetailID)
                    .OnDelete(DeleteBehavior.Cascade);
        });

    }

    public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        builder.AddConsole();
    });
}
