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
        public IActionResult GetAllDoctors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
        {
            try
            {
                var paginatedData = _adminService.GetAllDoctors(pageNumber, pageSize, search);
                return Ok(paginatedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
   
        [HttpGet("GetAllPatients")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllPatients([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
        {
            try
            {
                var paginatedData = _adminService.GetAllPatients(pageNumber, pageSize, search);
                return Ok(paginatedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    
        [HttpPost("AddDoctor")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> AddDoctor(Doctor doctor)
        {
            var doc = await _adminService.AddDoctor(doctor);

            if (doc != true)
                return false;
            
            return true;
        }


        [HttpPost("AddCoupon")]
        [Authorize(Roles = "Admin")]
        public bool AddCoupon(CouponPayload obj)
        {
            return _adminService.AddCoupon(obj);
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


        [HttpDelete("DeleteCoupon")]
        [Authorize(Roles = "Admin")]
        public bool DeleteCoupon(int id)
        {
            return _adminService.DeleteCoupon(id);
        }

        [HttpDelete("DeleteDoctor")]
        [Authorize(Roles = "Admin")]
        public bool DeleteDoctor(string id)
        {
            var doc = _adminService.DeleteDoctor(id);

            if (doc != true)
                return false;

            return true;
        }

        [HttpPost("DeactivateCoupon")]
        [Authorize(Roles = "Admin")]
        public bool DeactivateCoupon(int id)
        {
            return _adminService.DeactivateCoupon(id);
        }
        
        
    }
}
