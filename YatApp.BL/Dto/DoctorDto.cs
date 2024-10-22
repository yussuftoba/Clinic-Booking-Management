using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class DoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? ConsultationFee { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Availability { get; set; } = true;

        public int? ExperienceYears { get; set; }
        public string? Qualifications { get; set; }
        public float? Rating { get; set; } = 4;
        public string Image { get; set; }

        public int? SpecializationId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; } = string.Empty;

    }
}
