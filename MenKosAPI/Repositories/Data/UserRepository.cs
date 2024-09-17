using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class UserRepository : GeneralRepositories<User>
    {
        private readonly MyContext _context;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            _context = myContext;
        }
    }
}
