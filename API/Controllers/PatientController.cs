using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algoriza_Internship_BE133.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBookingService _bookingService;
        public PatientController(IPatientService adminService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IBookingService bookingService)
        {
            _patientService = adminService;
            _signInManager = signInManager;
            _userManager = userManager;
            _bookingService = bookingService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(Patient patient)
        {
            var doc = await _patientService.Register(patient);

            if (doc != true)
                return BadRequest(doc);

            return Ok(doc);
        }

        [HttpPost("Login")]
        public async Task<bool> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }

            return false;
        }

        [HttpGet("SearchDoctors")]
        public IActionResult SearchDoctors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var paginatedData = _patientService.GetAllDoctors(pageNumber, pageSize);
                return Ok(paginatedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("BookADoctor")]
        public bool BookADoctor([FromBody] Booking request)
        {
            bool bookingResult = _bookingService.MakeBooking(request.PatientId, request.DoctorId, request.TimeSlotId);

            if (bookingResult)
            {
                return true;
            }

            return false;

        }
    }
}
