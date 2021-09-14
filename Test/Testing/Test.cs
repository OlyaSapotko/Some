using System;
using NUnit.Framework;
using FinalTask.Utils;
using Aquality.Selenium.Browsers;
using FinalTask.PageObjects;
using Aquality.Selenium.Core.Logging;
using FinalTask.ApiApplication;

namespace FinalTask.Testing
{

    public class Test:BaseTest
    {
        private ProjectsPage projectsPage = new ProjectsPage();
        private SelectProjectPage selprojPage = new SelectProjectPage();
        private AddProjectPage projectForm = new AddProjectPage();
        private CreatedProjectPage createdProject = new CreatedProjectPage();
        private Logger log = AqualityServices.Logger;

        [Test]
        public void Test1()
        {
            string token = AppRequest.GetToken("apiQuery.json", "getToken", "testData.json", "variant");
            Assert.IsNotNull(token, "Token not received");
            log.Info("Token received");
            AqualityServices.Browser.GoTo(JsonRead.JsonParseData("config.json", "webUrl"));
            AqualityServices.Browser.Maximize();
            projectsPage.SendCookie(token);           
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(projectsPage.IsAssertVersion("testData.json", "variant"), "Version does not match");
            log.Info("Cookies sent, version matches");
            string projectName = JsonRead.JsonParseData("testData.json", "project");
            string projectId = projectsPage.GetProjectId(projectName);
            projectsPage.SelectProject(projectName);
            log.Info("The page of the selected project is open");        
            var listTests=AppRequest.GetTests("apiQuery.json", "getTests", projectId);
            var listTestsDate=selprojPage.Tests();
            Assert.IsTrue(selprojPage.IsAssertSortTestDate(listTestsDate), "Tests are not sorted");
            log.Info("Tests on the project page are sorted");
            Assert.IsTrue(selprojPage.IsCompareListsTests(listTests, listTestsDate), "Tests don't match");
            log.Info("The tests are the same");
            AqualityServices.Browser.GoBack();
            string tab = AqualityServices.Browser.Tabs().CurrentTabHandle;
            projectsPage.AddProject();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            log.Info("The page for adding projects is open");
            string rndProjectName = Randomize.RandomText();            
            projectForm.CreateProject(rndProjectName);
            Assert.IsTrue(projectForm.IsAssertCreateProject(), "Project not created");
            AqualityServices.Browser.Tabs().SwitchToTab(tab);
            log.Info("Project created");
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(projectsPage.IsAssertNewCreateProject(rndProjectName), "The project is not in the list of projects on the page");
            log.Info("The project is in the list of projects on the page");
            projectsPage.SelectProject(rndProjectName);
            log.Info("The page of the created project is open");
            string screen = Convert.ToBase64String(AqualityServices.Browser.GetScreenshot());
            string testName = Randomize.RandomText();
            AppRequest.CreateTest(rndProjectName, screen, testName, "apiQuery.json", "addLog", "createTest", "testData.json", "env", "addScreen");           
            Assert.IsTrue(createdProject.IsAssertCreateTest(testName), "Test record not created");
            log.Info("Test record created");
        }
    }
}
