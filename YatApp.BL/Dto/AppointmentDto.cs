using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ClinicManagement.BL.Dto
{
    public class AppointmentDto
    {
        public DateTime? AppointmentDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
        public string Symptoms { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public IFormFile? File { get; set; }
        public string? FileUrl { get; set; } // Display the file path in the API response

        // For uploading a file in POST/PUT

    }
}
