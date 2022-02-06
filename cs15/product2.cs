using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs15
{
    public partial class product
    {
        public string description { get; set; }
        public string expired { get; set; }
        public int id { get; set; }
        public void abc()
        {
            Console.WriteLine(this.name);
        }
        public nhaxuong from;
        public class nhaxuong
        {
            public string nha_xuong { get; set; }
        }
        
    }
}
