using EvoChat.Services.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoChat.Services.Orders.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
