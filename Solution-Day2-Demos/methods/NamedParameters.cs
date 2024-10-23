using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    internal class NamedParameters
    {
        public void empDetails(int age, string name, int exp, float salary)
        {
            Console.WriteLine($"The emp name is {name} \n" + $"emp age is {age} \n " + $"experience is {exp} \n"
                + $"salary is {salary}");
        }
    }
}
