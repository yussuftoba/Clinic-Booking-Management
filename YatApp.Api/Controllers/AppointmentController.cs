using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Interfaces;
using YatApp.Api;
using Models;
using ClinicManagement.BL.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Dto;
using ClinicManagement.BL.CheckLogin;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace ClinicsBookingDEPIProject.Controllers
{
    public class AppointmentController : BaseApiController
    {

        public AppointmentController(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _unitofWork.Appointments.GetByIdAsync(id); // Await the asynchronous call

            if (appointment == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return Ok(appointment); // Pass the appointment to the view
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            // Retrieve the appointment by ID
            var appointment = _unitofWork.Appointments.GetById(id);

            if (appointment == null)
            {
                // Return 404 if the appointment is not found
                return NotFound("Appointment not found.");
            }

            // Delete the appointment
            _unitofWork.Appointments.Delete(appointment);
            _unitofWork.Save();

            // Return a 204 No Content response to indicate successful deletion
            return Ok(true);
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var dto = new List<AppointmentDto>();
            var appointments = _unitofWork.Appointments.FindAll(x => 1 == 1, new string[] { "Doctor", "Patient" });
            foreach (var appointment in appointments)
            {
                dto.Add(new AppointmentDto()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    Status = appointment.Status,
                    Symptoms = appointment.Symptoms,
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = appointment.Doctor.FirstName + " " + appointment.Doctor.LastName,
                    //FilePath = appointment.FilePath
                    // Return the file path or URL from the database
                    FileUrl = Url.Content($"~/Uploads/{appointment.FilePath}") // Assuming the files are saved in wwwroot/Uploads folder
                });
            }
            return Ok(dto);
        }


        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatientId(int patientId)
        {
            // Retrieve all appointments for the specified patient ID
            var dto = new List<AppointmentDto>();
            var appointments = _unitofWork.Appointments.FindAll(x =>x.PatientId==patientId, new string[] { "Doctor", "Patient" });
            foreach (var appointment in appointments)
            {
                dto.Add(new AppointmentDto()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    Status = appointment.Status,
                    Symptoms = appointment.Symptoms,
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = appointment.Doctor.FirstName + " " + appointment.Doctor.LastName,
                    FileUrl = appointment.FilePath
                });
            }
            return Ok(dto);
            // Check if there are no appointments for the patient
            if (dto == null || !dto.Any())
            {
                return NotFound(new { Message = "No appointments found for the specified patient." });
            }

            
        }



        [HttpPost("createwithfile")]
        public async Task<IActionResult> createwithfile([FromBody] AppointmentDto dto)
        {

           

            Appointment appointment = new Appointment()
            {
                AppointmentDate = dto.AppointmentDate,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                Status = dto.Status,
                Symptoms = dto.Symptoms,
                FilePath = "jhgjhhjgh" 
            };

            var createdAppointment = _unitofWork.Appointments.Add(appointment);
            _unitofWork.Save(); 

            return Ok(createdAppointment);
        }


    }

}
