using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Repository.Implementation;
using SchoolManagementSystem.Repository.Interface;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolManagementController : Controller
    {
        private readonly ISchoolManagement _schoolManagement;
        public SchoolManagementController(ISchoolManagement schoolManagement)
        {
            _schoolManagement = schoolManagement;
        }

        [HttpGet]
        [Route("Get-All-School")]
        public async Task<IActionResult> GetAllSchool()
        {
            try
            {
                var allSchool = await _schoolManagement.GetAllSchool();
                if (allSchool == null)
                {
                    return NotFound("No school found");
                }
                return Ok(allSchool);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("School-By-Id")]
        public async Task<IActionResult> GetSchoolById(string schoolId)
        {
            try
            {
                var schoolById = await _schoolManagement.GetSchoolById(schoolId);
                if (schoolById == null)
                    return NotFound("school not found");
                return Ok(schoolById);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }




        [HttpPost]
        [Route("Create-School")]
        public async Task<IActionResult> CreateSchool(SchoolDto schoolDto)
        {
            try
            {
                var add = await _schoolManagement.CreateSchool(schoolDto);
                if (add.IsSuccessful)
                {
                    return Ok(add);
                }
                return BadRequest(add);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [Route("Delete-School")]
        public async Task<IActionResult> DeletSchool(string id)
        {
            try
            {
                await _schoolManagement.DeleteSchool(id);
                return Ok("successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Update-School")]
        public async Task<IActionResult> UpdatSchool(SchoolDto schoolDto, string schoolId)
        {
            try
            {
                var result = await _schoolManagement.UpdateSchool(schoolDto, schoolId);
                if (result.IsSuccessful)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
