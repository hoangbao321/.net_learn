using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs15
{
    public partial class product
    {

        public string name { get; set; }
        public double price { get; set; }
        public string getinfo()
        {
            return this.description+" "+this.id+" "+this.expired;
        }
        public Manufactory manufactory;
        public class Manufactory
        {
            public string name { get; set; }
            public string addr { get; set; }
        }
    }
}
