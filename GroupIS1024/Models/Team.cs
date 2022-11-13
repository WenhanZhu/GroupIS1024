using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace GroupIS1024.Models
{
    public class Team
    {
        [JsonProperty("Team Id")]
        public int TeamId { get; set; }

        [JsonProperty("Team Name")]
        public string TeamName { get; set; }

        public List<Coach>? Coaches { get; set; }

        public List<Player>? Players { get; set; }


    }
}
