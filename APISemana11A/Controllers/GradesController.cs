using APISemana11A.Models;
using APISemana11A.Requests;
using APISemana11A.Responses;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISemana11A.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public GradesController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        // POST: Insertar un nuevo grado
        [HttpPost]
        public IActionResult Insert(Grade request)
        {
            Grade grade = new Grade
            {
                Name = request.Name,
                Description = request.Description,
                isActive = true
            };

            _context.Grades.Add(grade);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Insert), new { id = grade.GradeID }, grade);
        }

        // PUT: Eliminación lógica de un grado
        [HttpPut]
        public void LogicalDelete(CourseRequestV4 request)
        {
            // Busco el curso con la información proporcionada
            Grade grade = _context.Grades.Where(x => x.GradeID == request.Id).FirstOrDefault();

            if (grade != null)
            {
                grade.isActive = request.isActive.ToLower() == "true";
                _context.Entry(grade).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
