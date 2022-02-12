using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_exception
{
    public class NameEmptyException :Exception
    {
        public NameEmptyException(): base("ten phai khac rong")
        {

        }
    }
}
