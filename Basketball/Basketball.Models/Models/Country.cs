using System.Collections.Generic;

namespace Basketball.Models.Models
{
    public class Country
    {
        public Country()
        {
            Players = new List<Player>();
            Leagues = new List<League>();
            Teams = new List<Team>();
        }

        public int Id { get; set; }

        public string CountryName { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<League> Leagues { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
