using OpenQA.Selenium;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;
using FinalTask.Utils;
using Aquality.Selenium.Browsers;

namespace FinalTask.PageObjects
{

    public class ProjectsPage:Form
    {
        private static By pageElementLocator = By.TagName("footer");        
        private ILabel versionLabel(string fileName, string key) => ElementFactory.GetLabel(By.XPath($"//*[text()='Version: {JsonRead.JsonParseData(fileName, key)}']"), "Version");
        private ILink projName(string projectName) => ElementFactory.GetLink(By.XPath($"//*[text()='{projectName}']"), "ProjectName");
        private IButton add => ElementFactory.GetButton(By.XPath("//*[@target='_blank']"), "AddProject");

        public ProjectsPage() : base(pageElementLocator, "Page Open") { }

        public void SendCookie(string token)
        {
            Cookie cookie = new Cookie("token", token);
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(cookie);
        }

        public void SelectProject(string projectName)
        {                      
            projName(projectName).Click();                        
        }

        public string GetProjectId(string projectName)
        {
            string str = AqualityServices.Browser.Driver.FindElement(By.XPath($"//*[text()='{projectName}']")).GetAttribute("href");
            string[] id=str.Split(new char[] { '=' });
            return id[1];
        }

        public bool IsAssertVersion(string fileName, string key)
        {
            return versionLabel(fileName, key).State.IsDisplayed;
        }

        public void AddProject()
        {
            add.Click();
        }

        public bool IsAssertNewCreateProject(string projectName)
        {
            return projName(projectName).State.IsDisplayed;
        }
    }
}
