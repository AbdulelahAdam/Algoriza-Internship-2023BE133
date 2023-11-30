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
        public PatientController(IPatientService adminService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _patientService = adminService;
            _signInManager = signInManager;
            _userManager = userManager;
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
    }
}
