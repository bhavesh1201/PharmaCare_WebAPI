using PharmaCare.Models;
using System.Linq.Expressions;

namespace PharmaCare.Repository.IRepository
{
    public interface IDrugRepository : IRepository <Drug>  // Template for drug repository
    {



        Task UpdateAsync(Drug drug);    
       
    }
}
