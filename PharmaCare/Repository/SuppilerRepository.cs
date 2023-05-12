using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Repository.IRepository;

namespace PharmaCare.Repository
{
    public class SuppilerRepository : Repository<Supplier> , ISuppilerRepository 
    {

        private readonly PharmacyContext _context;


        public SuppilerRepository(PharmacyContext context) : base(context)
        {
            _context = context;

        }



        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await SaveAsync();
        }

       
    }
}
