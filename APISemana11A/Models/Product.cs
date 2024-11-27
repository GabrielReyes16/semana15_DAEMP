using System.ComponentModel.DataAnnotations.Schema;

namespace APISemana11A.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        [NotMapped]
        public string Category { get; set; }
        [NotMapped]
        public string Date { get; set; }
        [NotMapped]
        public string Description { get; set; }
  


    }
}
