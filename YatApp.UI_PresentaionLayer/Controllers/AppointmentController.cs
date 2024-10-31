using ApiConsume;
using ClinicManagement.BL.CheckLogin;
using ClinicManagement.BL.Dto;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace ClinicManagement.UI_PresentaionLayer.Controllers
{
    public class AppointmentController : Controller
    {
        private IApiCall _api;
        public AppointmentController(IApiCall api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            int z = CheckLogin.check;
            var appointments = await _api.GetAllAsync<AppointmentDto>($"Appointment/GetAppointmentsByPatientId/{CheckLogin.check}");
            if (appointments == null || !appointments.Any())
            {
                // Option 1: Return the same view with empty list
                return View(new List<AppointmentDto>());

                // Option 2: Return a specific "no appointments" view
                // return View("NoAppointments");
            }
            return View(appointments);
        }

        public async Task<IActionResult> CreateAppointment()
        {
            var doctors = await _api.GetAllAsync<Doctor>("Doctors/GetAll");
            ViewBag.docs = new SelectList(doctors, "PersonId", "FirstName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentDto dto)
        {
            var doctors = await _api.GetAllAsync<Doctor>("Doctors/GetAll");
            ViewBag.docs = new SelectList(doctors, "PersonId", "FirstName");

            if (ModelState.IsValid)
            {
                await _api.CreateAsync<AppointmentDto>("Appointment/createwithfile", dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

    }
}


