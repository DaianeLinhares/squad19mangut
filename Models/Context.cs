using Microsoft.EntityFrameworkCore;

namespace Mangut.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

    }
}
