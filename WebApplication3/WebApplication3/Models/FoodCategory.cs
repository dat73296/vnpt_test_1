using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("FoodCategories")]
    public class FoodCategory
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }


        public List<Food> Foods { get; set; }
      
    }
}
