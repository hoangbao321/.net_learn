using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ArticleTag
{
    [Key]
    public int ArticleTagId { get; set; }

    public int TagId { get; set; } // FK-> TagID
    [ForeignKey("TagId")]
    public Tag Tag { get; set; }

    public int ArticleId { get; set; } // FK-> Article
    [ForeignKey("ArticleId")]
    public Article Article { get; set; }

    // ví dụ TagID 1 , A ID : 2 : ok
    // 1 -3  ok
    // 1-2 thì ko 
    // => đánh chỉ mục
}
