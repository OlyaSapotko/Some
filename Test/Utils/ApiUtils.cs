using RestSharp;

namespace FinalTask.Utils
{

    public static class ApiUtils
    {
        static RestClient restClient = new RestClient(JsonRead.JsonParseData("config.json", "apiUrl"));

        public static string PostMethod(string request)
        {
            RestRequest restRequest = new RestRequest(request, Method.POST);
            IRestResponse restResponse = restClient.Execute(restRequest);
            string response = restResponse.Content;
            return response;
        }              
    }
}
