using APISemana11A.Models;
using APISemana11A.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISemana11A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public StudentsController(InvoiceContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Insert(Student request)
        {
            Student student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                isActive = true
            };
        
        _context.Students.Add(student);
        _context.SaveChanges();
        }


        [HttpPut]
        public void LogicalDelete(CourseRequestV4 request)
        {
            // Busco el curso con la información proporcionada
            Student student = _context.Students.Where(x => x.StudentID == request.Id).FirstOrDefault();

            if (student != null)
            {
                student.isActive = request.isActive.ToLower() == "true";
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
