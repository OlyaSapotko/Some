using Newtonsoft.Json;

namespace FinalTask.Models
{

    public class ModelTest
    {
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("startTime")]
        public string StartTime { get; set; }
        [JsonProperty("endTime")]
        public string EndTime { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

}
