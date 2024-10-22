using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YatApp.Api;

namespace ClinicManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenderController : BaseApiController
	{
		public GenderController(IUnitOfWork unitofWork) : base(unitofWork)
		{
		}
		[HttpGet("GetAllAsync")]
		public async Task<IActionResult> GetAllAsync()
		{
			var genders = await _unitofWork.Genders.GetAllAsync();
			return Ok(genders);

		}
	}
}
