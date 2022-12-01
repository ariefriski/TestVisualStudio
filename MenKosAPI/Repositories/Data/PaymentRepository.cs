using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class PaymentRepository : GeneralRepositories<Payment>
    {
        private readonly MyContext _context;
        public PaymentRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
