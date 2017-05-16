using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models.Models
{
    public class LeagueSeason
    {
        public LeagueSeason()
        {
            this.Teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public int SeasonId { get; set; }

        public Season Season { get; set; }

        public int LeagueId { get; set; }

        public League League { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
