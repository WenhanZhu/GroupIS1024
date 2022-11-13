using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace GroupIS1024.Models
{
    public class Player
    {
        [JsonProperty("Player Id")]
        public int PlayerId { get; set; }

        [JsonProperty("First Name")]
        public string FirstName { get; set; }

        [JsonProperty("Last Name")]
        public string LastName { get; set; }


        public string Position { get; set; }

        public string City { get; set; }

        public string State { get; set; }


        public int Experience { get; set; }


        public string University { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Team? Team { get; set; }


        public int? TeamId { get; set; }
    }
}
