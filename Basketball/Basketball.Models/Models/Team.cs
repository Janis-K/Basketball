namespace Basketball.Models.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }

        public Country TeamCountry { get; set; }
    }
}
