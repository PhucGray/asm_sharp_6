using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Models
{
    [Table("VATs")]
    public class VATModel
    {
        [Key]
        public int Id { get; set; }

        public double Value { get; set; } = 0;
    }
}
