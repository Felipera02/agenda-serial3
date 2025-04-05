using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class PersonalCalendarService
    {
        private readonly PersonalCalendarRepository _calendarRepository;

        public PersonalCalendarService(PersonalCalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        public async Task<PersonalCalendar?> GetCalendarByIdAsync(int id)
        {
            return await _calendarRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PersonalCalendar>> GetAllCalendarsAsync()
        {
            return await _calendarRepository.GetAllAsync();
        }

        public async Task<IEnumerable<PersonalCalendar>> GetCalendarsByUserIdAsync(int id)
        {
            return await _calendarRepository.Get(c => c.UserId == id);
        }

        public async Task CreateCalendarAsync(PersonalCalendar calendar)
        {
            await _calendarRepository.AddAsync(calendar);
        }

        public async Task UpdateCalendarAsync(PersonalCalendar calendar)
        {
            await _calendarRepository.UpdateAsync(calendar);
        }

        public async Task DeleteCalendarAsync(int id)
        {
            await _calendarRepository.DeleteAsync(id);
        }
    }
}
