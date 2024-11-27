using System.ComponentModel.DataAnnotations.Schema;

namespace APISemana11A.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean isActive { get; set; }
    }
}
