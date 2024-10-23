namespace ArraysDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[10];
            Console.WriteLine("enter elements");
            for(int i=0;i<10;i++)
            {
                num[i] = Convert.ToByte(Console.ReadLine());
            }
            Console.WriteLine("elements are ");
            //for (int i = 0; i < 10; i++)
            //{
            //num[i]++;
            //    Console.WriteLine(num[i]);
            //}

            // foreach loop is used to iterate thru an array or a colletion
            // syntax for foreach loop
            // foreach(type range_var in array/collection)
            // use range_var
            foreach (int temp in num)
                     Console.WriteLine(temp);


        }
    }
}
