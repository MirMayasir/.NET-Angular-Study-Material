using CalcLib;
namespace CalcLibDll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter two numbers");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            ICalculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(x, y));
            Console.WriteLine(calculator.multiply(x,y));
        }
    }
}
