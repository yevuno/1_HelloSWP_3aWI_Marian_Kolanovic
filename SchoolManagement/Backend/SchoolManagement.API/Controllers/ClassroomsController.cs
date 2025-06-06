using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Models;
using SchoolManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ClassroomsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
            return await _context.Classrooms
                .Include(c => c.Students)
                .Include(c => c.Teachers)
                .ToListAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        // POST: api/Classrooms
        [HttpPost]
        public async Task<ActionResult<Classroom>> CreateClassroom(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.Id }, classroom);
        }

        // PUT: api/Classrooms/5/students/3
        [HttpPut("{classroomId}/students/{studentId}")]
        public async Task<IActionResult> AddStudentToClassroom(int classroomId, int studentId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(c => c.Id == classroomId);

            if (classroom == null)
                return NotFound("Classroom not found");

            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return NotFound("Student not found");

            if (!classroom.AddStudent(student))
                return BadRequest("Not enough space or seats in the classroom");

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/Classrooms/5/teachers/3
        [HttpPut("{classroomId}/teachers/{teacherId}")]
        public async Task<IActionResult> AddTeacherToClassroom(int classroomId, int teacherId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(c => c.Id == classroomId);

            if (classroom == null)
                return NotFound("Classroom not found");

            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                return NotFound("Teacher not found");

            if (!classroom.AddTeacher(teacher))
                return BadRequest("Not enough space or seats in the classroom");

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Classrooms/5/students/3
        [HttpDelete("{classroomId}/students/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromClassroom(int classroomId, int studentId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == classroomId);

            if (classroom == null)
                return NotFound("Classroom not found");

            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return NotFound("Student not found");

            if (!classroom.RemoveStudent(student))
                return NotFound("Student not found in classroom");

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Classrooms/5/teachers/3
        [HttpDelete("{classroomId}/teachers/{teacherId}")]
        public async Task<IActionResult> RemoveTeacherFromClassroom(int classroomId, int teacherId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(c => c.Id == classroomId);

            if (classroom == null)
                return NotFound("Classroom not found");

            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                return NotFound("Teacher not found");

            if (!classroom.RemoveTeacher(teacher))
                return NotFound("Teacher not found in classroom");

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Classrooms/5/space
        [HttpGet("{id}/space")]
        public async Task<ActionResult<object>> GetClassroomSpace(int id)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (classroom == null)
                return NotFound();

            return new
            {
                TotalSquareMeters = classroom.SquareMeters,
                AvailableSquareMeters = classroom.GetAvailableSpace(),
                TotalSeats = classroom.Seats,
                AvailableSeats = classroom.GetAvailableSeats(),
                StudentCount = classroom.Students.Count,
                TeacherCount = classroom.Teachers.Count
            };
        }
    }
}