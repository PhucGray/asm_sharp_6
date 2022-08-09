using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Models.More
{
    public class UpdateUserReqModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int RoleId { get; set; }
    }
}
