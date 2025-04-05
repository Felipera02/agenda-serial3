using Backend.Data;
using Backend.Models;

namespace Backend.Repositories
{
    public class PersonalCalendarRepository : GenericRepository<PersonalCalendar>
    {
        public PersonalCalendarRepository(AgendaContext context) : base(context) { }
    }
}
