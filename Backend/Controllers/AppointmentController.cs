using Microsoft.AspNetCore.Mvc;
using Backend.Services; // Certifique-se de que o serviço de Appointment está sendo importado corretamente
using Backend.Models;   // Certifique-se de que o modelo Appointment está sendo importado

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
        {
            return Ok(await _appointmentService.GetAllAppointmentsAsync());
        }

        [HttpGet("by-calendar")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetCalendarsByUserId([FromQuery] int calendarId)
        {
            return Ok(await _appointmentService.GetAppointmentsByCalendarIdAsync(calendarId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }

            await _appointmentService.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
                return BadRequest();

            await _appointmentService.UpdateAppointmentAsync(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }
}
