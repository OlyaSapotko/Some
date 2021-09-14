using System.Collections.Generic;
using FinalTask.Models;
using Newtonsoft.Json;
using FinalTask.Utils;

namespace FinalTask.ApiApplication
{ 

    public static class AppRequest
    {

        public static string GetToken(string fileName1, string key1, string fileName2, string key2)
        {
            string token = ApiUtils.PostMethod(ApiQueryBuilder.GetToken(fileName1, key1, fileName2, key2));
            return token;
        }        

        public static List<ModelTest> GetTests(string fileName1, string key1, string projectId)
        {
            string tests = ApiUtils.PostMethod(ApiQueryBuilder.GetTests(fileName1, key1, projectId));
            List<ModelTest> listTests = JsonConvert.DeserializeObject<List<ModelTest>>(tests);           
            return listTests;
        }

        public static void CreateTest(string projectName, string image, string testName, string fileName, string key, string key1, string fileName2, string key2, string key3)
        {
            string testId = ApiUtils.PostMethod(ApiQueryBuilder.CreateTest(projectName, testName, fileName, key1, fileName2, key2));
            ApiUtils.PostMethod(ApiQueryBuilder.AddLog(testId, fileName, key));
            ApiUtils.PostMethod(ApiQueryBuilder.AddScreen(testId, image, fileName, key3));            
        }        
    }
}
