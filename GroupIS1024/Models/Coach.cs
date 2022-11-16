using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroupIS1024.Models
{
    public class Coach

    {
        public int CoachId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Member Status")]
        public bool? IsMemberStatus { get; set; }


        public Team Team { get; set; }


        public int TeamId { get; set; }

    }
}
