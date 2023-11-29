using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algoriza_Internship_BE133.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpGet("GetPatientById")]
        public IActionResult GetPatientById(int patientId)
        {
            var patient = _adminService.GetPatientById(patientId);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpGet("GetDoctorById")]
        public IActionResult GetDoctorById(int id)
        {
            var doc = _adminService.GetDoctorById(id);

            if (doc == null)
                return NotFound();

            return Ok(doc);
        }

        [HttpGet("GetAllDoctors")]
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
        
        [HttpGet("GetAllPatients")]
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
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            var doc = await _adminService.AddDoctor(doctor);

            if (doc != true)
                return BadRequest(doc);
            
            return Ok(doc);
        }

        //[HttpPost("AddPatient")]
        //public IActionResult AddPatient(Patient patient)
        //{
        //    var usr = _adminService.Register(patient);

        //    if (usr != true)
        //        return NotFound();

        //    return Ok(usr);
        //}

        [HttpPut("EditDoctor")]
        public IActionResult EditDoctor(Doctor changedDoctor)
        {
            var doc = _adminService.EditDoctor(changedDoctor);

            if (doc != true)
                return NotFound();

            return Ok(doc);
        }

        [HttpDelete("DeleteDoctor")]
        public IActionResult DeleteDoctor(int id)
        {
            var doc = _adminService.DeleteDoctor(id);

            if (doc != true)
                return NotFound();

            return Ok(doc);
        }
    }
}
