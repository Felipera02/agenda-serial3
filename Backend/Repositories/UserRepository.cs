using Backend.Data;
using Backend.Models;

namespace Backend.Repositories
{
    public class UserRepository(AgendaContext context) : GenericRepository<User>(context)
    {
    }
}
