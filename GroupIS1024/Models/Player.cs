using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GroupIS1024.Models
{
    public class Player
    {

        public int PlayerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Team Name")]
        public string LastName { get; set; }

        [DisplayName("Position")]
        public string Position { get; set; }


        [DisplayName("Team Name")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Experience")]
        public int Experience { get; set; }

        [DisplayName("University")]
        public string? University { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public Team? Team { get; set; }

        public int TeamId { get; set; }
    }
}
