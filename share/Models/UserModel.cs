using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        public bool Gender { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        public bool IsDeleted { get; set; } = false;

        //
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
