using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*MethodOverloading MO = new MethodOverloading();
      
            Console.WriteLine(MO.add(2, 4));*/

            /*NamedParameters NP = new NamedParameters();
            NP.empDetails(name: "mayasir", age: 23, exp: 1, salary: 23348.3f);
        }*/

            /*DefaultParameters DP = new DefaultParameters();
            Console.WriteLine(DP.SI(2000, 4, 2));*/

            /*OutputParameters OP = new OutputParameters();
            int add, sub, product;
            OP.operations(10, 20,
                out add, out sub, out product);

            Console.WriteLine($"the addition is {add} \n the subtraction is {sub} \n the product is {product}");*/

            /*CallByValueCallByRef CBVCBR = new CallByValueCallByRef();
            int x = 10;
            Console.WriteLine($"the value of x in main before change1 {x}");
            CBVCBR.change1(ref x);
            Console.WriteLine($"the value of x in main after calling change1 {x}");*/

            ParamsArray paramsArray = new ParamsArray();
            paramsArray.unknownArray(1, 2, 3, 4, 5, 5);
        }
    }
}
