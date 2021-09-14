using System;
using FinalTask.Utils;
using System.IO;

namespace FinalTask.Models
{

    public abstract class ApiQueryBuilder
    {

        public static string GetToken(string fileName1, string key1, string fileName2, string key2)
        {
            string tokenQuery = JsonRead.JsonParseData(fileName1, key1) + "variant="+ JsonRead.JsonParseData(fileName2, key2);
            return tokenQuery;
        }

        public static string GetTests(string fileName1, string key1, string projectId)
        {
            string testsQuery = JsonRead.JsonParseData(fileName1, key1) + "projectId="+projectId;
            return testsQuery;
        }

        public static string CreateTest(string projectName, string testName, string fileName1, string key1, string fileName2, string key2)
        {
            string crTest=@JsonRead.JsonParseData(fileName1, key1)+"SID="+Randomize.RandomText()
                +"&projectName="+projectName+"&testName="+testName+"&methodName="+Randomize.RandomText()+"&env="+ 
                JsonRead.JsonParseData(fileName2, key2);
            return crTest;
        }

        public static string AddLog(string testId, string fileName, string key)
        {            
            string log = Convert.ToBase64String(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory+"Log\\log.log"));
            string addLog = JsonRead.JsonParseData(fileName, key) + "testId=" + testId + "&content=" + log;
            return addLog;
        }

        public static string AddScreen(string testId, string image, string fileName, string key)
        {
            string addScreen = JsonRead.JsonParseData(fileName, key) + "testId=" + testId + "&content=" + image + "&contentType=png";
            return addScreen;
        }
    }
}
