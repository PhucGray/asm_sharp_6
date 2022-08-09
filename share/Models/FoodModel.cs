using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Models
{
    [Table("Foods")]
    public class FoodModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public double Price { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Image { get; set; }

        public bool Status { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        //
        public ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
