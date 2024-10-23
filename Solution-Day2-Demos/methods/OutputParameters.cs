using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    internal class OutputParameters
    {
        public void operations(int x, int y,
            out int add,
            out int sub,
            out int product)
        {
            add = x + y;
            sub = x - y;
            product = y*x;
        }
    }
}
