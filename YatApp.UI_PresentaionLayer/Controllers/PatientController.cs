using ApiConsume;
using ClinicManagement.BL.CheckLogin;
using ClinicManagement.BL.Dto;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace YatApp.UI_PresentaionLayer.Controllers
{
    public class PatientController : Controller
    {
        private IApiCall _api;

        public PatientController(IApiCall api)
        {
            _api = api;
        }

        public async Task<IActionResult> SignUp()
        {
            var genders = await _api.GetAllAsync<Gender>("Gender/GetAllAsync");
            ViewBag.genders = new SelectList(genders, "Id", "GenderName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(PatientDto dto)
        {
            var genders =await _api.GetAllAsync<Gender>("Gender/GetAllAsync");
            ViewBag.genders = new SelectList(genders, "Id", "GenderName");

            if (ModelState.IsValid)
            {
                var res =await _api.GetByIdAsync<bool>($"Patient/isValidEmail?email={dto.Email}");
                if (res)
                {
                    await _api.CreateAsync<PatientDto>("Patient/AddAsync", dto);

                    return RedirectToAction("SignIn","Patient");
                }
                else
                {
                    ModelState.AddModelError("Email", "this mail already exist");
                    return View();
                }
            }
          return View();
        }

        public async Task<IActionResult> SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signIn)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    var res = await _api.GetByIdAsync<Patient>($"Patient/IsValidLoginIn?email={signIn.Email}&password={signIn.Password}");

                    if (res != null)
                    {
                        CheckLogin.check = res.PersonId;
                        CheckLogin.patientName = res.FirstName + " " + res.LastName;
                        return RedirectToAction("Index", "Appointment");
                    }

                    ModelState.AddModelError("", "Email or Password is incorrect, Please try again!");
                }
                catch (HttpRequestException ex)
                {
                
                    ModelState.AddModelError("", "Unable to process login request. Please try again later.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                }
            }
            return View(signIn);
        }

        public IActionResult SignOut()
        {
            CheckLogin.check = 0;

            return RedirectToAction("Index", "Doctor");
        }
    }
}
