using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cs43_EF4_2.Models
{
    [Table("DonhangChitiet")]
    public partial class DonhangChitiet
    {
        [Key]
        [Column("DonhangChitietID")]
        public int DonhangChitietId { get; set; }
        [Column("DonhangID")]
        public int? DonhangId { get; set; }
        [Column("SanphamID")]
        public int? SanphamId { get; set; }
        public int? Soluong { get; set; }
    }
}
