using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Category
{
    [Key]
    public int CateGoryID { get; set; }
    [StringLength(50)]
    public string Name { get; set; }

    [Column(TypeName = "ntext")]
    public string Description { get; set; }

    // Collect Navigation : điều hướng tập hợp
    // thêm từ khóa virtual vì dung nameaspace Micro.Framworkcore.Proxier
    public virtual List<Product> Products { get; set; }

    public virtual CategoryDetail categorydetail { get; set; }


}

