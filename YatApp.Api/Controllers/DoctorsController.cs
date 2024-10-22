using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using YatApp.Api;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : BaseApiController
	{

		public DoctorsController(IUnitOfWork unitofWork) : base(unitofWork)
		{
		}

		[HttpPost("AddAsync")]
		public async Task<IActionResult> AddAsync(DoctorDto dto)
		{
			//AutoMapper package
			Doctor Doctor = new Doctor()
			{
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				ConsultationFee = dto.ConsultationFee,
				Availability = dto.Availability,
				ExperienceYears = dto.ExperienceYears,
				Qualifications = dto.Qualifications,
				Rating = dto.Rating,
				Image = dto.Image,
				Email = dto.Email,
				Phone = dto.Phone,
				Password = dto.Password,


			};
			var res = await _unitofWork.Doctors.AddAsync(Doctor);
			_unitofWork.Save();
			return Ok(Doctor);
		}

		//[HttpGet("Search")]
		//public async Task<IActionResult> Search(string? name=null, string? city=null, int specializationId=0)
		//{
		//    var doc = await _unitofWork.Doctors.GetAllAsync();

		//    if (!string.IsNullOrEmpty(name))
		//    {
		//        doc= await _unitofWork.Doctors.FindAllAsync(x=> name.Contains(x.FirstName) || name.Contains(x.LastName));
		//    }

		//    if(specializationId!=0)
		//    {
		//        doc = await _unitofWork.Doctors.FindAllAsync(x => specializationId == x.SpecializationId, new string[] { "Specialization" });
		//    }


		//    if(!string.IsNullOrEmpty(city))
		//    {
		//        doc = await _unitofWork.Doctors.FindAllAsync(x =>x.Address.Contains(city));
		//    }

		//    return Ok(doc);
		//}


		[HttpGet("Search")]
		public async Task<IActionResult> Search(int? specializationId = null, string? name = null)
		{
			var doc = await _unitofWork.Doctors.GetAllAsync();

			if (!string.IsNullOrEmpty(name))
			{
				doc = await _unitofWork.Doctors.FindAllAsync(x => name.Contains(x.FirstName) || name.Contains(x.LastName));
			}
			if (specializationId != null)
			{
				doc = await _unitofWork.Doctors.FindAllAsync(x => specializationId == x.SpecializationId, new string[] { "Specialization" });
			}

			return Ok(doc);
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var doctors = await _unitofWork.Doctors.GetAllAsync();
			return Ok(doctors);
		}



	}
}
