using PharmaCare.Data;
using PharmaCare.Models;
using PharmaCare.Repository.IRepository;

namespace PharmaCare.Repository
{
    public class FeedbackRepository : Repository <Feedback> , IFeedbackRepository
    {


        public readonly PharmacyContext Context;
        public FeedbackRepository(PharmacyContext _context) : base(_context)
        {
            Context = _context;
        }

    }
}
