using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("FoodOrders")]
    public class FoodOrder
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public float Quantity { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int TotalMoney { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


    }
}
