using Backend.Data;
using Backend.Models;

namespace Backend.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(AgendaContext context) : base(context) { }
    }
}
