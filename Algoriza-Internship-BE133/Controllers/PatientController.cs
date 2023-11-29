using Core.Models;
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

        public PatientController(IPatientService adminService)
        {
            _patientService = adminService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(Patient patient)
        {
            var doc = await _patientService.Register(patient);

            if (doc != true)
                return BadRequest(doc);

            return Ok(doc);
        }
    }
}
