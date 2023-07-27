using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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

        public  Task ChangePrice(int  id , int price)
        {
            return Task.FromResult(0);
        } 

      public async Task<List<Order>> GetAllSupWithCart()
        {
            var temp =  context.Orders.Include(x=>x.Carts).ToList();
            return temp;
        }

        public async Task UpdateAsync(Order order)
        {


            var temp =  context.Orders.Where(x=>x.OrderId==order.OrderId).Include(x=>x.Carts).AsNoTracking().FirstOrDefault();
            foreach(var item in temp.Carts)
            {

               await QuntityUpdate(item.SupplierId, item.Quntity);


            }
            
           context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        public async Task QuntityUpdate(int id , int qunt)
        {
            var temp =  context.Suppliers.Where(x => x.SuppilerId == id).FirstOrDefault();
            temp.quntity -= qunt;
            context.Suppliers.Update(temp);
            await context.SaveChangesAsync();



        }

        public async Task<List<Order>> GetAllOrderByEmail(string email)
        {
            var temp =  context.Orders.Where(z=>z.Email==email).ToListAsync();
            return await temp;
        }

        public async Task DeleteAsync(int id)
        {

            var temp = context.Orders.Where(x => x.OrderId == id).Include(x => x.Carts).FirstOrDefault();

            temp.Carts = null;
            
               context.Orders.Update(temp);
            await context.SaveChangesAsync();


             context.Orders.Remove(temp);
           


        }
    }
}
