namespace CalPrj
{
    public interface ICalculator
    {
        public int add(int x, int y);
        public int subtract(int x, int y);

        public int multiply(int x, int y);
        public int divide(int x, int y);

        public string message(string name);

        public bool checkAge(int age);

        public int increment(int x);

        public string Login(string username, string password);

        public int CheckTemp(bool check);
    }
    public class Calculator : ICalculator
    {
        public int add(int x, int y)
        {
            int z = increment(x);
            return z + y;
        }

        public bool checkAge(int age)
        {
            if (age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CheckTemp(bool check)
        {
            if (check)
            {
                return 42;
            }
            else
            {
                throw new InvalidOperationException("temprature not initialized");
            }
        }

        public int divide(int x, int y)
        {
            return x / y;
        }

        public int increment(int x)
        {
            return x + 1;
        }

        public string Login(string username, string password)
        {
            string msg;
            if((username == "user_1" && password == "secret@user11") || (username == "user_2" && password == "secret@user22")) {
                msg = "welcome " + username;
            }
            else
            {
                msg = "invalid user";
            }
            return msg;
        }

        public string message(string name)
        {
            return "hello " + name;
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
