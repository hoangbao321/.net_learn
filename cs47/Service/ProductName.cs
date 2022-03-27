using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs47.Service
{
    // tạo ra dịch vụ product name, đăng kí vào DI của hệ thống
    public class ProductName
    {
        private List<string> names { get; set; }
        // ko có inject dependency
        public ProductName()
        {
            names = new List<string>()
            {
                "iphoneaaa", "ipadaaaa","laptopaaaa",
            };
        }
        public List<string> GetName() => names; 
    }
}
