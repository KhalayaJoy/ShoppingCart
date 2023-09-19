using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Model
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=X10-PF2SLGFJ\\SQLEXPRESS2019; initial Catalog=shoppingcart; User Id=myusername; password=1234; TrustServerCertificate= True");
        }

    }
}
