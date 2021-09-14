using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;
using FinalTask.Models;

namespace FinalTask.PageObjects
{

    public class SelectProjectPage:Form
    {
        private static By pageElementLocator = By.TagName("footer");
        private By path = By.XPath("//*[@class='table']//tr//td[4]");

        public SelectProjectPage():base(pageElementLocator, "Page Open") { }

        public List<string> Tests()
        {
            List<string> listDate = new List<string>();
            var list = ElementFactory.FindElements<ILabel>(path);
            
            for (int i=0; i<list.Count; i++ )
            {
                listDate.Add(list[i].GetText());
            }
            return listDate;
        }

        public bool IsAssertSortTestDate(List<string> listDate)
        {
            for (int i = 0; i < listDate.Count-1; i++)
            {
                if (Convert.ToDateTime(listDate[i]) < Convert.ToDateTime(listDate[i + 1]))
                    return false;
            }
            return true;
        }
        
        public bool IsCompareListsTests(List<ModelTest> listTests, List<string> listTestsDate)
        {
            List<string> startDateList = new List<string>();
            for (int i = 0; i < listTests.Count; i++)
            {
                startDateList.Add(listTests[i].StartTime);
            }
            startDateList.Sort();
            startDateList.Reverse();
            List<string> listForCompare = startDateList.GetRange(0, listTestsDate.Count);
            for (int i = 0; i < listTestsDate.Count; i++)
            {
                if (listForCompare[i] != listTestsDate[i])
                    return false;
            }
            return true;
        }
    }
}
