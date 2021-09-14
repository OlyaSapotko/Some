using OpenQA.Selenium;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;

namespace FinalTask.PageObjects
{

    public class CreatedProjectPage:Form
    {
        private static By pageElementLocator = By.TagName("footer");
        private static ILink tNameLink(string testName) => ElementFactory.GetLink(By.XPath($"//*[text()='{testName}']"), "TestNameLink");

        public CreatedProjectPage() : base(pageElementLocator, "Page Open") { }

        public bool IsAssertCreateTest(string testName)
        {
            return tNameLink(testName).State.WaitForDisplayed();
        }
    }
}
