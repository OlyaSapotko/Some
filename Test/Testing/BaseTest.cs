using NUnit.Framework;
using Aquality.Selenium.Browsers;

namespace FinalTask
{

    [TestFixture]
    public class BaseTest
    {

        [SetUp]
        public void BeforeTest()
        {            
        }

        [TearDown]
        public void AfterTest()
        {
            AqualityServices.Browser.Quit();
        }
    }
}