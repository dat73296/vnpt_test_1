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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
       

    }
}
