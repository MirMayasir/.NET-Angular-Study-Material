namespace cal
{
    public interface ICalculator
    {
        int add(int x, int y);
        int subtract(int x, int y);
        int multiply(int x, int y);
        int divide(int x, int y);
        int inc(int x);

        string message(string name);
        bool checkAge(int age);
        int CheckTemp(bool f);
        string Login(string username, string password);

    }
    public class Calculator : ICalculator
    {
        public int add(int x, int y)
        {
            int z = inc(x);
            return z + y;
        }
        public int subtract(int x, int y) { return x - y; }
        public int multiply(int x, int y) { return x * y; }
        public int divide(int x, int y) { return x / y; }

        public int inc(int x)
        {
            return x + 1;
        }

        public string message(string name)
        {
            return "Hello " + name;
        }

        public bool checkAge(int age)
        {
            if (age > 18)
                return true;
            else
                return false;
        }

        public int CheckTemp(bool f)
        {
            if (f)
            {
                return 42;
            }
            else
            {
                throw new InvalidOperationException("Temperature not Intialized");
            }
        }

        public string Login(string username, string password)
        {
            string msg;
            if ((username == "user_11" && password == "secret@user11") || (username == "user_22" && password == "secret@user22"))
            {
                msg = "Welcome " + username;
            }
            else
            {
                msg = "Invalid User Id/Password";
            }
            return msg;
        }
    }
}
