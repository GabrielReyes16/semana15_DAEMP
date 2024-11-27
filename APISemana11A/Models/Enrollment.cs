namespace APISemana11A.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public DateTime Date { get; set; }

        //Crear llave foránea
        public int CourseID { get; set; }
        public Course Course { get; set; }

       

    }
}
