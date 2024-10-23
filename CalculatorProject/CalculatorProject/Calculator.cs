namespace CalculatorProject
{
    public interface Calculator
    {
        public int add(int x, int y);
        public int subtract(int x, int y);

        public int multiply(int x, int y);
        public int divide(int x, int y);  
    }
    public class Icalculator : Calculator
    {
        public int add(int x, int y)
        {
            return x + y;
        }

        public int divide(int x, int y)
        {
            return x / y;
        }

        public int multiply(int x, int y)
        {
            return x * y;
        }

        public int subtract(int x, int y)
        {
            return x - y;
        }
    }

}
