using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseApiController
    {
        public PatientController(IUnitOfWork unitofWork):base(unitofWork) 
        {         
        }
        #region Get
        
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var res = _unitofWork.Patients.GetById(id);
            return Ok(res);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _unitofWork.Patients.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet("isValidEmail")]
        public async Task<IActionResult> isValidEmail(string email)
        {
            var res = await _unitofWork.Patients.FindAsync(m=>m.Email==email);
            if (res == null)
            {
                return Ok(true); 
            }
            return Ok(false);
        }

        [HttpGet("IsValidLoginIn")]
        public async Task<IActionResult> IsValidLoginIn(string email, string password)
        {
            var res = await _unitofWork.Patients.FindAsync(m => m.Email == email && m.Password==password);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }


        #endregion

        #region Add


        [HttpPost("Add")]
        public IActionResult Add(PatientDto dto)
        {
            Patient Patient = new Patient()
            {
                 FirstName = dto.FirstName,
                 LastName = dto.LastName,   
                 Address = dto.Address,
                 DateOfBirth = dto.DateOfBirth,
                 Email = dto.Email,
                 GenderId = dto.GenderId,
                 InsuranceID = dto.InsuranceID,
                 Password = dto.Password,
                 Phone = dto.Phone,
                 
                 
            };
            var res = _unitofWork.Patients.Add(Patient);
            _unitofWork.Save();
            return Ok(Patient);
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(PatientDto dto)
        {
            //AutoMapper package
            Patient Patient = new Patient()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                GenderId = dto.GenderId,
                InsuranceID = dto.InsuranceID,
                Password = dto.Password,
                Phone = dto.Phone,
            };
            var res = await _unitofWork.Patients.AddAsync(Patient);
            _unitofWork.Save();
            return Ok(Patient);
        }
        #endregion

        #region Update
        [HttpPut("Update")]
        public IActionResult Update(Patient model)
        {
            var res = _unitofWork.Patients.Update(model);
            _unitofWork.Save();
            return Ok(model);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(Patient model)
        {
            var res = _unitofWork.Patients.Update(model);
            _unitofWork.Save();
            return Ok(model);
        }
        
        #endregion
      
        #region Delete
        [HttpDelete("Delete")]
        public IActionResult Delete(Patient model)
        {
              _unitofWork.Patients.Delete(model);
            _unitofWork.Save();
            return Ok("Deleted");
        }

        
        #endregion
    }
}
