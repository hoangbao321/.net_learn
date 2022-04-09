using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs40_EF1
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }

        public string Provider { get; set; }

        public override string ToString()
        {
            return $"{ProductID}-{ProductName}-{Provider}";
        }
    }
}
