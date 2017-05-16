using System.Collections.Generic;

namespace Basketball.Models.Models
{
    public class Position
    {
        public Position()
        {
            Players = new List<Player>();
        }

        public int Id { get; set; }

        public string PositionName { get; set; }

        public virtual IEnumerable<Player> Players { get; set; }
    }
}
