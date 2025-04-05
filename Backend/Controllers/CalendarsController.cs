using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarsController : ControllerBase
    {
        private readonly PersonalCalendarService _calendarService;

        public CalendarsController(PersonalCalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalCalendar>> GetCalendar(int id)
        {
            var calendar = await _calendarService.GetCalendarByIdAsync(id);
            if (calendar == null)
                return NotFound();
            return Ok(calendar);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalCalendar>>> GetAllCalendars()
        {
            return Ok(await _calendarService.GetAllCalendarsAsync());
        }

        [HttpGet("by-user")]
        public async Task<ActionResult<IEnumerable<PersonalCalendar>>> GetCalendarsByUserId([FromQuery] int userId)
        {
            return Ok(await _calendarService.GetCalendarsByUserIdAsync(userId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCalendar(PersonalCalendar calendar)
        {
            await _calendarService.CreateCalendarAsync(calendar);
            return CreatedAtAction(nameof(GetCalendar), new { id = calendar.Id }, calendar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCalendar(int id, PersonalCalendar calendar)
        {
            if (id != calendar.Id)
                return BadRequest();

            await _calendarService.UpdateCalendarAsync(calendar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCalendar(int id)
        {
            await _calendarService.DeleteCalendarAsync(id);
            return NoContent();
        }
    }
}
