using ApiConsume;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Xml.Linq;

namespace ClinicManagement.UI_PresentaionLayer.Controllers
{
    public class DoctorController : Controller
    {
        private IApiCall _api;
        public DoctorController(IApiCall api)
        {
            _api = api;
        }
        public async Task<IActionResult> Index()
        {
            var spec =await _api.GetAllAsync<Specialization>("Specializaion/GetAllAsync");
            ViewBag.specs = new SelectList(spec, "SpecializationId", "SpecializationName");

            return View();
        }
        //[HttpPost]
        [HttpPost]
        public async Task<IActionResult> Index(SearchDto dto)
        {
            var spec = await _api.GetAllAsync<Specialization>("Specializaion/GetAllAsync");
            ViewBag.specs = new SelectList(spec, "SpecializationId", "SpecializationName");
            var doctors = await _api.GetAllAsync<Doctor>($"Doctors/Search?specializationId={dto.SpecializationId}&name={dto.Name}");
            return PartialView("_Doctors",doctors);
        }
    }
}
