using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public static class XYZ
    {
        public static double Binhphuong(this double x) => x * x;
        public static double Canbachai(this double x) => Math.Sqrt(x);
        public static double Sin(this double x) => Math.Sin(x);
    }
}
