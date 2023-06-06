using PharmaCare.Models;

namespace PharmaCare.Repository.IRepository
{
    public interface ISuppilerRepository : IRepository <Supplier>
    {
        Task UpdateAsync(Supplier supplier);
        Task<List<Supplier>> GetAllSupWithDrug();

    }
}
