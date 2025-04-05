
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        private DateTime _birthday;

        [Required]
        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public List<PersonalCalendar> PersonalCalendars { get; set; } = [];
    }
}
