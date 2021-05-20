using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("User")]
    public class User
    {
       

        [Key]
        [Display(Name ="User")]
        [Required]
        [MaxLength(10)]
        public string UserName { get; set; }

        [Display(Name = "Pass")]
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }


        public List<FoodOrder> FoodOrders { get; set; }
    }
}
