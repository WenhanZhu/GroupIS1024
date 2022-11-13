using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GroupIS1024.Models
{
    public class Team
    {

        public int TeamId { get; set; }

        [DisplayName("Team Name")]
        public string TeamName { get; set; }

        public List<Coach> Coaches { get; set; }

        public List<Player> Players { get; set; }


    }
}
