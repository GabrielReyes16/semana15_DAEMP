using System.ComponentModel.DataAnnotations.Schema;

namespace APISemana11A.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public string Grade { get; set; }
        [NotMapped]
        public bool IsActive { get; set; }

    }
}
