using EvoChat.Services.ShoppingCart.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoChat.Services.ShoppingCart.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartMaster> CartMasters { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
