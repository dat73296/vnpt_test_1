using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    [Table("Foods")]
    public class Food
    {
       
        [Key]
        [Display(Name ="ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required]
        public float Price { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string Image { get; set; }

        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }


        public List<FoodOrder> FoodOrders { get; set; }


    }

}
