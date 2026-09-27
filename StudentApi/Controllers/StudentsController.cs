using Microsoft.AspNetCore.Mvc;
using StudentApi.DTOs;
using StudentApi.Models;
using StudentApi.Services;


namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentDto dto)
        {
            var student = _studentService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateStudentDto dto)
        {
            var success = _studentService.Update(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _studentService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
