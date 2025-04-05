using Backend.Data;
using Backend.Models;

namespace Backend.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public AppointmentRepository(AgendaContext context) : base(context) { }
    }
}
