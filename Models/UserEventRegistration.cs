using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistration.Models
{
    public class UserEventRegistration
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
        public string UniversityGraduationDate { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public long DateRegistraion { get; set; }
        public bool StatusRegistration { get; set; }
    }
}
