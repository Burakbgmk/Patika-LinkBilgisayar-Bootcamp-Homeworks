using ApiWeb.Entities;
namespace ApiWeb.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

    }
}
