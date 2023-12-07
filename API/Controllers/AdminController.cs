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
        public IActionResult GetPatientById([FromQuery] int Id)
        {
            var patient = _adminService.GetPatientById(Id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }


        [HttpGet("GetDoctorById")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDoctorById([FromQuery] int id)
        {
            var doc = _adminService.GetDoctorById(id);

            if (doc == null)
                return NotFound();
            //doc.UserImage = "C:\\CodeRepository\\cSharp\\dotnet\\AlgorizaPractice\\Project\\API\\wwwroot\\images\\doctor_images\\Dr.House.png";
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
        public async Task<bool> AddDoctor([FromBody] Doctor doctor)
        {
            var doc = await _adminService.AddDoctor(doctor);

            if (doc != true)
                return false;

            return true;
        }


        [HttpPost("AddCoupon")]
        [Authorize(Roles = "Admin")]
        public bool AddCoupon([FromBody] CouponPayload obj)
        {
            return _adminService.AddCoupon(obj);
        }


        [HttpPut("EditDoctor")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditDoctor([FromBody] Doctor changedDoctor)
        {
            var doc = _adminService.EditDoctor(changedDoctor);

            if (doc != true)
                return NotFound();

            return Ok(doc);
        }


        [HttpDelete("DeleteCoupon")]
        [Authorize(Roles = "Admin")]
        public bool DeleteCoupon([FromQuery] int id)
        {
            return _adminService.DeleteCoupon(id);
        }

        [HttpDelete("DeleteDoctor")]
        [Authorize(Roles = "Admin")]
        public bool DeleteDoctor([FromQuery] string id)
        {
            var doc = _adminService.DeleteDoctor(id);

            if (doc != true)
                return false;

            return true;
        }

        [HttpPost("DeactivateCoupon")]
        [Authorize(Roles = "Admin")]
        public bool DeactivateCoupon([FromQuery] int id)
        {
            return _adminService.DeactivateCoupon(id);
        }


        [HttpPut("UpdateCoupon")]
        [Authorize(Roles = "Admin")]
        public bool UpdateCoupon([FromQuery] int id, [FromBody] CouponPayload obj)
        {
            return _adminService.UpdateCoupon(id, obj);
        }




        [HttpGet("Statistics/NumberOfDoctors")]
        [Authorize(Roles = "Admin")]
        public int NumberOfDoctors()
        {
            return _adminService.NumberOfDoctors();
        }


        [HttpGet("Statistics/NumberOfPatients")]
        [Authorize(Roles = "Admin")]
        public int NumberOfPatients()
        {
            return _adminService.NumberOfPatients();
        }

        [HttpGet("Statistics/NumberOfRequests")]
        [Authorize(Roles = "Admin")]
        public int NumberOfRequests()
        {
            return _adminService.NumberOfRequests();
        }


        [HttpGet("Statistics")]
        [Authorize(Roles = "Admin")]
        public IActionResult Statistics()
        {
            var last24HoursPatients = _adminService.PatientsRegisteredLast24Hours();
            var last24HoursDoctors = _adminService.DoctorsRegisteredLast24Hours();
            var last24HoursRequests = _adminService.RequestsMadeLast24Hours();


            //var lastWeekPatients = _adminService.PatientsRegisteredLast24Hours();
            //var lastWeekDoctors = _adminService.DoctorsRegisteredLast24Hours();
            //var lastWeekRequests = _adminService.RequestsMadeLast24Hours();


            //var lastMonthPatients = _adminService.PatientsRegisteredLast24Hours();
            //var lastMonthDoctors = _adminService.DoctorsRegisteredLast24Hours();
            //var lastMonthRequests = _adminService.RequestsMadeLast24Hours();


            //var lastYearPatients = _adminService.PatientsRegisteredLast24Hours();
            //var lastYearDoctors = _adminService.DoctorsRegisteredLast24Hours();
            //var lastYearRequests = _adminService.RequestsMadeLast24Hours();

            var statistics = new
            {
                Last_24_Hours_Patients = last24HoursPatients,
                Last_24_Hours_Doctors = last24HoursDoctors,
                Last_24_Hour_Requests = last24HoursRequests,

                //    Last_Week_Patients = last24HoursPatients,
                //    Last_Week_Doctors = last24HoursDoctors,
                //    Last_Week_Requests = last24HoursRequests


                //    Last_Month_Patients = last24HoursPatients,
                //    Last_Month_Doctors = last24HoursDoctors,
                //    Last_Month_Requests = last24HoursRequests


                //    Last_Year_Patients = last24HoursPatients,
                //    Last_Year_Doctors = last24HoursDoctors,
                //    Last_Year_Requests = last24HoursRequests
            };

            return Ok(statistics);

        }

    }
}
