namespace GroupIS1024.Models
{
    public class Coach
    {
        public int CoachId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string State { get; set; }

        public Boolean Memberstatus { get; set; }

        public Team Team { get; set; }


        public int TeamId { get; set; }

    }
}
