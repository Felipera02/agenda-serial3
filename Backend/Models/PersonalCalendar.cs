using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class PersonalCalendar
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual List<Appointment> Appointments { get; set; } = [];
    }
}
