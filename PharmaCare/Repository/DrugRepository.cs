using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Repository.IRepository;
using System.Linq.Expressions;

namespace PharmaCare.Repository
{
    public class DrugRepository :  Repository<Drug> , IDrugRepository   
    {

        private readonly PharmacyContext _context;


        public DrugRepository(PharmacyContext context) : base(context)
        {
            _context = context; 
            
        }
       

       
        public async Task UpdateAsync(Drug drug)
        {
            _context.Drugs.Update(drug);
            await SaveAsync();
        }

        

        
    }
}
