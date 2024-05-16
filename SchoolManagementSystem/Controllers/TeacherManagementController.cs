using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Repository.Interface;

namespace SchoolManagementSystem.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class TeacherManagementController : Controller
    {
        private readonly ITeacherManagement teacherManagement;

        public TeacherManagementController(ITeacherManagement teacherManagement)
        {
            this.teacherManagement = teacherManagement;
        }


        [HttpPost]
        [Route("Add-Teachers")]
        public async Task<IActionResult> AddTeacher(CreateTeacherDto createTeacherDto)
        {
           var add = teacherManagement.AddTeacher(createTeacherDto);
            if (add != null)
            {
            return Ok(add);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Delete-Teacher")]
        public IActionResult DeleteTeacher(string deleteTeacherId)
        {
            var delete = teacherManagement.DeleteTeacher(deleteTeacherId);
            if (delete != null)
            {
                return Ok(delete);
            }
                return BadRequest("incomplete");
        }

        [HttpGet]
        [Route("Get-All-Teachers")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var allTeacher = await teacherManagement.GetAllTeacher();
            if (allTeacher == null)
            {
                return NotFound();
            }
            return Ok(allTeacher);
        }

        [HttpGet]
        [Route("Get-Teacher-By-Id")]
        public async Task<IActionResult> GetTeacherById([FromRoute] string getTeacherId)
        {
            var teacherId = await teacherManagement.GetTeacherById(getTeacherId);
            if (teacherId == null)
            {
                return NotFound();
            }
            return Ok(teacherId);
        }

        [HttpPost]
        [Route("Update-Teacher")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDto UpdateTeacherDto, string updateTeacherId)
        {
            var update = teacherManagement.UpdateTeacher(UpdateTeacherDto, updateTeacherId);
            if (update != null)
            {
                return Ok(update);
            }
            return BadRequest("teacher not updated");
        }
    }



}
