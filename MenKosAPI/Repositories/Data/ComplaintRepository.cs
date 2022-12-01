using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class ComplaintRepository : GeneralRepositories<ComplaintTicket>
    {
        private MyContext _context;
        public ComplaintRepository(MyContext myContext) : base(myContext)
        {
            _context = myContext;
        }
    }
}
