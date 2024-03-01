using EvoChat.Services.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoChat.Services.Products.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
