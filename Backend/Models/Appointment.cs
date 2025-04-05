using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public int CalendarId { get; set; }
        public PersonalCalendar? PersonalCalendar { get; set; }
    }
}
