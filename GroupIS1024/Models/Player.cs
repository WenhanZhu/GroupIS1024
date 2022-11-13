using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GroupIS1024.Models
{
    public class Player
    {

        public int PlayerId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Position { get; set; }

        public string City { get; set; }

        public string State { get; set; }


        public int Experience { get; set; }


        public string? University { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Team? Team { get; set; }

        public int TeamId { get; set; }
    }
}
