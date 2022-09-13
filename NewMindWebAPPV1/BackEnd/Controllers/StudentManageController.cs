using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.EfCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentManageController : Controller
    {
        private readonly StudentDbContext dbContext;

        public StudentManageController(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await dbContext.Students.ToListAsync());

        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest createStudentRequest)
        {
            var student = new Student()
            {
                id = Guid.NewGuid(),
                Name = createStudentRequest.Name,
                age = createStudentRequest.age,
                PhoneNumber = createStudentRequest.PhoneNumber,
                Addres = createStudentRequest.Addres,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return Ok(student);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, UpdateStudentRequest updateStudentRequest)
        {
            var student = dbContext.Students.Find(id);
            if (student != null)
            {
                student.Name = updateStudentRequest.Name;
                student.age = updateStudentRequest.age;
                student.PhoneNumber = updateStudentRequest.PhoneNumber;
                student.Addres = updateStudentRequest.Addres;

                await dbContext.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                dbContext.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return NotFound();
        }

    }
}
