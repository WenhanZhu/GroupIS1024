using Newtonsoft.Json;

namespace GroupIS1024.Models
{
    public class Coach
    {
        [JsonProperty("Coach Id")]
        public int CoachId { get; set; }

        [JsonProperty("First Name")]
        public string FirstName { get; set; }

        [JsonProperty("Last Name")]
        public string LastName { get; set; }

        [JsonProperty("User Name")]
        public string UserName { get; set; }

        public string State { get; set; }

        [JsonProperty("Coach Status")]
        public Boolean CoachStatus { get; set; }

        public Team? Team { get; set; }

        public int? TeamId { get; set; }

    }
}
