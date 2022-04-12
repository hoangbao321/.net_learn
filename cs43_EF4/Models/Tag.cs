using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tag
{
    //[Key]
    //[StringLength(20)]
    //public string TagID { get; set; }
    [Column(TypeName = "ntext")]
    public string Content { get; set; }
    [Key]
    public int TagId { get; set; }
}
