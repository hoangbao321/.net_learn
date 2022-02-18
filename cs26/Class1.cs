using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs26
{
    class Class1
    {
        public static int Binary_search(int[] a, int l, int r, int x)
        {
            if( l > r)
            {
                return -1;
            }
            else if( a[(l+r)/2] == x  )
            {
                return (l + r) / 2;
            }
            else if( a[(l + r) / 2] < x )
            {
                l = (l+r)/2+1;
                return Binary_search(a, l, r, x);
            }
            // a[(l + r) / 2] >  x
            r = (l + r) / 2 - 1;
            return Binary_search(a, l, r, x);
        }
    }
    // extension method
    static class Z
    {
        public static int Tinhbinhphuong(this int s)
        {
            return s * s;
        }
        public static double Tinhbinhphuong(this double s)
        {
            return s * s;
        }
    }
}
