using CalPrj;

namespace CalculatorTest
{
    public class Tests
    {
        ICalculator obj;
        [SetUp]
        public void Setup()
        {
            obj = new Calculator();
        }

        [Test]
        public void TestAdd()
        {
            int actualResult = obj.add(2, 3);
            int expectedResult = 6;
            Assert.AreEqual(expectedResult, actualResult);

        }
        [Test]
        public void TestMult()
        {
            int actualResult = obj.multiply(2, 3);
            int expectedResult = 6;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestMessage()
        {
            string actualResult = obj.message("mayasir");
            string expectedResult = "hello mayasir";
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestBoolTrue()
        {
            bool actualResult = obj.checkAge(20);
            Assert.AreEqual(actualResult, true);
        }
        [Test]
        public void TestBoolFalse()
        {
            bool actualResult = obj.checkAge(2);
            Assert.AreEqual(actualResult, false);
        }

        [Test]
        public void TestIncrement()
        {
            int actuaResult = obj.increment(6);
            Assert.AreEqual(actuaResult, 7);
        }

        [TestCase("user_1" , "secret@user11")]
        [TestCase("user_2", "secret@user22")]
        public void TestLoginFail(string username, string password)
        {
            string msg = obj.Login(password, username);
            string msg2 = "invalid user";
            Assert.That(msg2, Is.EqualTo(msg));
        }

        [TestCase("user_1", "secret@user11")]
        [TestCase("user_2", "secret@user22")]
        public void TestLoginPass(string username, string password)
        {
            string msg = obj.Login(username,password);
            string msg2 = "welcome " + username;
            Assert.That(msg2, Is.EqualTo(msg));
        }

        [Test]
        public void TestTempFail()
        {
            Assert.Throws<InvalidOperationException>(() => obj.CheckTemp(false));
        }


        [Test]
        public void TestTempPass()
        {
            int res = obj.CheckTemp(true);
            Assert.AreEqual(res, 42);
        }
    }
}