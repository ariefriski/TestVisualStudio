using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class OrderRepository : GeneralRepositories<Order>
    {
        private readonly MyContext _context;
        public OrderRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
