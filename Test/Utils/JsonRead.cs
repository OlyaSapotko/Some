using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace FinalTask.Utils
{

    public static class JsonRead
    {
        
        public static string JsonParseData(string fileName, string key)
        {            
            JObject objParse = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Resources\\" +fileName));
            string value1 = objParse[key].ToString();
            return value1;
        }
    }
}
