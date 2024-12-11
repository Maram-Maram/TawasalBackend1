//using Microsoft.AspNetCore.Mvc;
//using TawasalBackend1.Data;
//using TawasalBackend1.Models;
//using Microsoft.EntityFrameworkCore;

//namespace TawasalBackend1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CoursesController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public CoursesController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Courses
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
//        {
//            return await _context.Courses.ToListAsync();
//        }

//        // GET: api/Courses/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Course>> GetCourse(int id)
//        {
//            var course = await _context.Courses.FindAsync(id);

//            if (course == null)
//            {
//                return NotFound();
//            }

//            return course;
//        }

//        // POST: api/Courses
//        [HttpPost]
//        public async Task<ActionResult<Course>> AddCourse([FromBody] Course course)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Courses.Add(course);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
//        }

//        // PUT: api/Courses/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
//        {
//            if (id != course.CourseId)
//            {
//                return BadRequest("Course ID mismatch");
//            }

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Entry(course).State = EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        // DELETE: api/Courses/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCourse(int id)
//        {
//            var course = await _context.Courses.FindAsync(id);
//            if (course == null)
//            {
//                return NotFound();
//            }

//            _context.Courses.Remove(course);
//            await _context.SaveChangesAsync();

//            return NoContent();

//        }


//    }
//}
//+++++++++++++++++++++++++
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TawasalBackend1.Data;
//using TawasalBackend1.Models;

//namespace TawasalBackend1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CoursesController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public CoursesController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
//        {
//            var courses = await _context.Courses.ToListAsync();

//            foreach (var course in courses)
//            {
//                course.Link = $"{Request.Scheme}://{Request.Host}/api/Courses/{course.CourseId}";
//            }

//            return Ok(courses);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Course>> GetCourse(int id)
//        {
//            var course = await _context.Courses.FindAsync(id);

//            if (course == null)
//            {
//                return NotFound();
//            }

//            course.Link = $"{Request.Scheme}://{Request.Host}/api/Courses/{course.CourseId}";

//            return Ok(course);
//        }
//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TawasalBackend1.Data;
using TawasalBackend1.Models;

namespace TawasalBackend1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CoursesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }

        // GET: api/Courses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            // Return the newly created course with a 201 status
            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
        }

        // PUT: api/Courses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest("Course ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/Courses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        // Helper method to check if a course exists
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
