using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YatApp.Api;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializaionController : BaseApiController
    {
        public SpecializaionController(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }
        // GET: api/<DoctorsController>
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var specs = await _unitofWork.Specializations.GetAllAsync();
            return Ok(specs);

        }
    }
}
