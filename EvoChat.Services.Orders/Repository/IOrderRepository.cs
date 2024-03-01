using EvoChat.Services.Orders.DbContexts;
using EvoChat.Services.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoChat.Services.Orders.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderMaster orderMaster);
        Task UpdateOrderPaymentStatus(Guid orderId, bool paid);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;
        public OrderRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddOrder(OrderMaster orderMaster)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            _db.OrderMaster.Add(orderMaster);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(Guid orderId, bool paid)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            var orderHeaderFromDb = await _db.OrderMaster.FirstOrDefaultAsync(u => u.OrderId == orderId);
            if (orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();
            }
        }
    }
}
