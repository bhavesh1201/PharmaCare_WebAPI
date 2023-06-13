using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Repository.IRepository;

namespace PharmaCare.Repository
{
    public class OrderRepository : Repository<Order> ,IOrderRepository
    {

        public readonly PharmacyContext context;
        public OrderRepository(PharmacyContext _context) : base(_context)
        {
            context = _context;
        }

        public Task GetAll(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order order)
        {
           context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
