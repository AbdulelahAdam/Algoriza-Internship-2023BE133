using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Algoriza_Internship_BE133.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IUserLoginService _userLoginService;
        private readonly IBookingService _bookingService;
        public PatientController(IPatientService patientService, IBookingService bookingService, IUserLoginService userLoginService)
        {
            _patientService = patientService;
            _bookingService = bookingService;
            _userLoginService = userLoginService;
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Patient patient)
        {
            var doc = await _patientService.Register(patient);

            if (doc != true)
                return BadRequest(doc);

            return Ok(doc);
        }
        
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Patient userLogin)
        {
            var user = _userLoginService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _userLoginService.Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }
        [HttpGet("SearchDoctors")]
        [Authorize(Roles = "Patient")]
        public IActionResult SearchDoctors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
        {
            try
            {
                var paginatedData = _patientService.GetAllDoctors(pageNumber, pageSize, search);
                return Ok(paginatedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost("BookADoctor")]
        [Authorize(Roles = "Patient")]
        public bool BookADoctor([FromBody] BookingPayload obj)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            bool bookingResult = _bookingService.MakeBooking(obj, userId);

            if (bookingResult)
            {
                return true;
            }

            return false;

        }


        [HttpPut("CancelBooking")]
        [Authorize(Roles = "Patient")]
        public bool CancelBooking([FromQuery] int Id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            bool bookingResult = _bookingService.CancelBooking(Id, userId);

            if (bookingResult)
            {
                return true;
            }

            return false;

        }


        [HttpGet("GetAllBookings")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetAllBookings()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = _patientService.GetAllBookings(userId);

            if (result != null)
            {
                return Ok(result);
            }

            return Ok("[]");

        }
    }
}
