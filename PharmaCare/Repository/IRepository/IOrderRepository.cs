using PharmaCare.Models;
using System.Threading.Tasks;

namespace PharmaCare.Repository.IRepository
{
    public interface IOrderRepository : IRepository <Order>
    {
        Task UpdateAsync(Order order);

        Task<List<Order>> GetAllSupWithCart();

        Task<List<Order>> GetAllOrderByEmail(string email);

        Task DeleteAsync(int id);
    }
}
