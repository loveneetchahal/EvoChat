using EvoChat.Services.Coupons.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoChat.Services.Coupons.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; } 
    }
}
