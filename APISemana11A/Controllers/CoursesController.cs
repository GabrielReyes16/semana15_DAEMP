using APISemana11A.Models;
using APISemana11A.Requests;
using APISemana11A.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISemana11A.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CoursesController(InvoiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        [HttpGet]
        public List<CourseResponseV1> GetAllName()
        {
            List< Course> courses= _context.Courses.ToList();

            List<CourseResponseV1> response = courses.Select(x => new CourseResponseV1
            {
                Id = x.CourseID,
                Name = x.Name
            }).ToList();

            return response;
        }

        [HttpGet]
        public List<Course> Get()
        {
            return _context.Courses.ToList();
        }

        //[HttpPost]
        //public void Insert(Course product)
        //{
        //    _context.Courses.Add(product);
        //    _context.SaveChanges();
        //}

        [HttpPost]
        public void Insert(CourseRequestV1 request)
        {
            Course course = new Course
            {
                Name = request.Name,
                Credit = request.Credit,
                IsActive=true
                
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdateCredit(CourseRequestV2 request)
        {
            //Busco el producto con la información
           
            Course course= _context.Courses.Where(x=>x.CourseID==request.Id).FirstOrDefault();
            course.Credit=request.Credit;            
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPut]
        public void UpdateData(CourseRequestV3 request)
        {
            //Busco el producto con la información

            Course course = _context.Courses.Where(x => x.CourseID == request.Id).FirstOrDefault();
            course.Name = request.Name;
            course.Description = request.Description;
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();

        }
        [HttpPut]
        public void LogicalDelete(CourseRequestV4 request)
        {
            // Busco el curso con la información proporcionada
            Course course = _context.Courses.Where(x => x.CourseID == request.Id).FirstOrDefault();

            if (course != null)
            {
                course.IsActive = request.isActive.ToLower() == "true";
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


    }
}
