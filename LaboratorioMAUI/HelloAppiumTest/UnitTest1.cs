using OpenQA.Selenium.Appium;

namespace HelloAppiumTest
{
    public class Tests
    {
        /*Annotation*/
        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}