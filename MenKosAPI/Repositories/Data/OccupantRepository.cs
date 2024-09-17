using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class OccupantRepository : GeneralRepositories<Occupant>
    {
        private readonly MyContext _context;
        public OccupantRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
