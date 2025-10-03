using Microsoft.AspNetCore.Mvc;
using StudentsCRUDAPIs.DAO;
using StudentsCRUDAPIs.Models;

namespace StudentsCRUDAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsControllers : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsControllers(AppDbContext context)
        {
            this._context = context;
        }

        //get all students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        //get student by id
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //create new student
        [HttpPost]
        public IActionResult CreateNewProduct([FromBody] Students students)
        {
            if (students == null) return BadRequest();
            _context.Students.Add(students);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudentById), new { id = students.Id }, students);
        }

        //update student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Students students)
        {
            if (students == null || students.Id != id) return BadRequest();
            var existingStudent = _context.Students.Find(id);
            if (existingStudent == null) return NotFound();
            existingStudent.FirstName = students.FirstName;
            existingStudent.LastName = students.LastName;
            existingStudent.DateOfBirth = students.DateOfBirth;
            existingStudent.Email = students.Email;
            existingStudent.EnrollmentDate = students.EnrollmentDate;
            _context.Students.Update(existingStudent);
            _context.SaveChanges();
            return Ok(existingStudent);
        }

        //delete student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existingStudent = _context.Students.Find(id);
            if (existingStudent == null) return NotFound();
            _context.Students.Remove(existingStudent);
            _context.SaveChanges();
            return Ok("Student deleted successfully");
        }
    }
}