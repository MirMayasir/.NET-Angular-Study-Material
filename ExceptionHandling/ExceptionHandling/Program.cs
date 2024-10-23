namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int num1, num2, result =0;
            try
            {
                Console.WriteLine("enter num1");
                num1 = Convert.ToInt32(Console.ReadLine());
                if(num1 >= 0 || num1 <= 10)
                {
                    throw new Exception("not in range");
                }

                Console.WriteLine("enter num2");
                num2 = Convert.ToInt32(Console.ReadLine());


                result = num1 / num2;

            }
            catch (FormatException ex)
            {
                Console.WriteLine("only numbers are allowed");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("in finally block");
                Console.WriteLine(result);
            }

        }
    }
}
