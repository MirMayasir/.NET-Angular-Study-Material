namespace CalcLib
{
    public interface ICalculator
    {
        public int Add(int x, int y);
        public int multiply(int x, int y);
    }
    public class Calculator : ICalculator { 
        public int Add(int x, int y)
        {
                return x + y;
        }

        public int multiply(int x, int y)
        {
            return x * y;
        }
    }
}
