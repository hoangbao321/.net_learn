using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Product
{
    [Key]
    public int ProductID { get; set; }

    [StringLength(50)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string ProductName { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    /* 
     * CategID int? thì khi xóa bên bảng Category thì Product ko bị xóa do cho phép null
     *         int  thì ngược lại thì Product bị xóa vì ko cho phép null
    */
    public int CateID { get; set; }
    //[ForeignKey("CateID")] // dùng fluent API ko cần cái này
    public virtual Category Category { get; set; }

    public int CateID2 { get; set; }
    //[ForeignKey("CateId2")]
    //[InverseProperty("Products")]
    public virtual Category Category2 { get; set; }



    public override string ToString()
    {
        return $"id: {ProductID}-name: {ProductName}-{Price}-cateID: {CateID}";
    }
}
