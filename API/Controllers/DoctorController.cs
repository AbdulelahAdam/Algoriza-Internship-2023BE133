using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Algoriza_Internship_BE133.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IUserLoginService _userLoginService;
        public DoctorController(IDoctorService doctorService, IUserLoginService userLoginService)
        {
            _doctorService = doctorService;
            _userLoginService = userLoginService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Doctor userLogin)
        {
            var user = _userLoginService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _userLoginService.Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        [HttpGet("GetAllBookings")]
        [Authorize(Roles = "Doctor")]
        public IEnumerable<Booking> GetAllBookings([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] DateTime searchByDate)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string doctorId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _doctorService.GetAllBookings(doctorId, pageNumber, pageSize, searchByDate);
        }

        [HttpPost("ConfirmCheckUp")]
        [Authorize(Roles = "Doctor")]
        public bool ConfirmCheckUp([FromQuery] int Id) 
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string doctorId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _doctorService.ConfirmCheckUp(Id, doctorId);
        }


        [HttpPost("AddAppointment")]
        [Authorize(Roles = "Doctor")]
        public bool AddAppointment([FromBody] AppointmentPayload payload)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string doctorId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _doctorService.AddAppointment(doctorId, payload);
        }


        [HttpPut("UpdateAppointment")]
        [Authorize(Roles = "Doctor")]
        public bool UpdateAppointment([FromBody] AppointmentPayload payload)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string doctorId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _doctorService.UpdateAppointment(doctorId, payload);
        }


        [HttpDelete("DeleteAppointment")]
        [Authorize(Roles = "Doctor")]
        public bool DeleteAppointment([FromBody] AppointmentPayload payload)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string doctorId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _doctorService.DeleteAppointment(doctorId, payload);
        }

    }
}
