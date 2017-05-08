using System.Collections.Generic;

namespace Basketball.Models.Models
{
    public class Roster
    {
        public Roster()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int SeasonId { get; set; }

        public Season Season { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
