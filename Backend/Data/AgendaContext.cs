using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AgendaContext(DbContextOptions<AgendaContext> opt) : DbContext(opt)
    {
        DbSet<User> Users {  get; set; }
        DbSet<PersonalCalendar> PersonalCalendars {  get; set; }
        DbSet<Appointment> Appointments { get; set; }
    }
}
