using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Article
{
    [Key]
    public int AritcleID { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    [Column(TypeName ="ntext")]
    public string Content { get; set; }
}
