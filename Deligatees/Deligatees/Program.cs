namespace Deligatees
{
    internal class Program
    {

        public delegate int AddDel(int x, int y); 
        public delegate int ProDel(int x, int y);
        static void main(string[] args)
        {
            AddDel del1 = new AddDel(Add);
            int result = del1(2, 4);
            Console.WriteLine(result);

            AddDel del2 = new AddDel(mul);
            int product = del2(2, 4);
            Console.WriteLine(product);
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int mul(int x, int y)
        {
            return x *  y;
        }
    }
}
