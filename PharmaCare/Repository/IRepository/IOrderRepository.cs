using PharmaCare.Models;

namespace PharmaCare.Repository.IRepository
{
    public interface IOrderRepository : IRepository <Order>
    {
        Task UpdateAsync(Order order);

        Task GetAll(string name);
    }
}
