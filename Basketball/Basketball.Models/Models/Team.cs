using System.Collections.Generic;

namespace Basketball.Models.Models
{
    public class Team
    {
        public Team()
        {
            HomeGames = new List<Game>();
            AwayGames = new List<Game>();
        }

        public int Id { get; set; }

        public string TeamName { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }

        public Country TeamCountry { get; set; }

        public virtual ICollection<Game> HomeGames { get; set; }

        public virtual ICollection<Game> AwayGames { get; set; }
    }
}
