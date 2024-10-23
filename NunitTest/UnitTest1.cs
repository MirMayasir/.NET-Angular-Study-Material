using cal;

namespace NunitTest
{
    public class Tests
    {
        private ICalculator obj;
        [SetUp]
        public void Setup()
        {
            obj = new Calculator();
        }

        [Test]
        public void Test1()
        {
            int actualResult = obj.add(10, 10);
            int expectedResult = 10;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}