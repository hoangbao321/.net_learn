using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cs40_EF1
{
    public class ProductDbContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information );
            builder.AddConsole();
        });
        public DbSet<Product> products { get; set; }




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
        }
        
    }
}
