using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    internal class CallByValueCallByRef
    {
        public void change1(ref int x)
        {
            x = 100;
            Console.WriteLine($"the value of x in the change1 is {x}");
        }
    }
}
