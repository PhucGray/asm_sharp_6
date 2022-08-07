using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Models.UI
{
    public class FoodModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên món")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ảnh")]
        public string Image { get; set; } = "";

        public bool Status { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
    }
}
