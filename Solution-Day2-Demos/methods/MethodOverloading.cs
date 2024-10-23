using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    internal class MethodOverloading
    {
        public int add(int x, int y)
        {
            return x + y;
        }

        public int add(int y, int x, int z)
        {
            return x + y + z;
        }

        public float add(float x, int y)
        {
            return x - y;
        }
    }
}
