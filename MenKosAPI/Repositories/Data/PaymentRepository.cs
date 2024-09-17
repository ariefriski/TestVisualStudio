using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class PaymentRepository : GeneralRepositories<Payment>
    {
        private MyContext _context;
        public PaymentRepository(MyContext myContext) : base(myContext)
        {
            _context = myContext;
        }
    }
}
