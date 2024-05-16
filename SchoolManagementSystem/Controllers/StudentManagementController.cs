using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Enum;
using SchoolManagementSystem.Repository.Interface;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementController : Controller
    {
        private readonly IStudentManagement _studentManagement;
        public StudentManagementController(IStudentManagement studentManagement)
        {
            _studentManagement = studentManagement;
        }

        

        [HttpPost]
        [Route("Add-Student")]
        public async Task<IActionResult> AddStudent([FromBody]CreateStudentDto studentDto)
        {
            try
            {
                var add = await _studentManagement.AddStudent(studentDto);
                if (add != null)
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
        [Route("Delete-Student")]
        public IActionResult DeleteStudent(string studentId)
        {
            try
            {
            var delete = _studentManagement.DeleteStudent(studentId);
                if (delete != null)
                {
                    return Ok(delete);
                }
                return BadRequest("delete not successful"); // is this pattern ok for delete
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Get-All-Students")]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var allStudent = await  _studentManagement.GetAllStudent();
                if (allStudent != null)
                {
                return Ok(allStudent);
                }
                return BadRequest("students not found");
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Get-Students-By-Id")]
        public async Task<IActionResult> GetStudentById(string getStudentId)
        {
            try
            {
                var studentId = await _studentManagement.GetStudentById(getStudentId);
                if (studentId != null)
                {
                    return Ok(studentId);
                }
                return BadRequest("id not found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Update-Student")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto studentDto, string updateStudentId)
        {
            try
            {
                var update = await _studentManagement.UpdateStudent(studentDto, updateStudentId);
                if (update == null)
                {
                    return NotFound(update);
                }
                return Ok(update);

            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }

        }
    }
}
