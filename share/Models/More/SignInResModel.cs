using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Models.More
{
    public class SignInResModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
    }
}
