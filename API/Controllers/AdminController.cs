using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Algoriza_Internship_BE133.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserLoginService _userLoginService;
        public AdminController(IAdminService adminService, IUserLoginService userLoginService)
        {
            _adminService = adminService;
            _userLoginService = userLoginService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] ApplicationUser userLogin)
        {
            var user = _userLoginService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _userLoginService.Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        [HttpGet("GetPatientById")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPatientById(int patientId)
        {
            var patient = _adminService.GetPatientById(patientId);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

     
        [HttpGet("GetDoctorById")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDoctorById(int id)
        {
            var doc = _adminService.GetDoctorById(id);

            if (doc == null)
                return NotFound();

            return Ok(doc);
        }


        [HttpGet("GetAllDoctors")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDoctors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var paginatedData = _adminService.GetAllDoctors(pageNumber, pageSize);
                return Ok(paginatedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        
        [HttpGet("GetAllDoctorsBySearch")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDoctorsBySearch([FromQuery] string search = "")
        {
            try
            {
                var result = _adminService.GetAllDoctorsBySearch(search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
   
        [HttpGet("GetAllPatients")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllPatients([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var paginatedData = _adminService.GetAllPatients(pageNumber, pageSize);
                return Ok(paginatedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    
        [HttpPost("AddDoctor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            var doc = await _adminService.AddDoctor(doctor);

            if (doc != true)
                return BadRequest(doc);
            
            return Ok(doc);
        }

  
        [HttpPut("EditDoctor")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditDoctor(Doctor changedDoctor)
        {
            var doc = _adminService.EditDoctor(changedDoctor);

            if (doc != true)
                return NotFound();

            return Ok(doc);
        }
       
        [HttpDelete("DeleteDoctor")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDoctor(int id)
        {
            var doc = _adminService.DeleteDoctor(id);

            if (doc != true)
                return NotFound();

            return Ok(doc);
        }
    }
}
