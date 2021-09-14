using OpenQA.Selenium;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;

namespace FinalTask.PageObjects
{

    public class AddProjectPage:Form
    {
        private static By formElementLocator = By.XPath("//form");
        private ITextBox inputProjectName => ElementFactory.GetTextBox(By.XPath("//*[@class='form-control']"), "InputProjectName");
        private IButton saveProject => ElementFactory.GetButton(By.XPath("//*[@type='submit']"), "SaveProject");
        private ILabel successSave => ElementFactory.GetLabel(By.XPath("//*[contains(@class, 'alert alert-success')]"), "successSaveLabel");
        
        public AddProjectPage():base(formElementLocator, "Form Open") { }

        public void CreateProject(string projectName)
        {
            inputProjectName.SendKeys(projectName);
            saveProject.Click();
        }

        public bool IsAssertCreateProject()
        {            
            return successSave.State.IsDisplayed;
        }
    }
}
