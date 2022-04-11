using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CategoryDetail
{
    public int CategoryDetailID { get; set; }
    public int UserId { get; set; }
    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public int CountProduct { get; set; }
    public virtual Category category { get; set; }
}

