using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basketball.Models.Models
{
    public class Player
    {
        public Player()
        {
            this.Rosters = new HashSet<Roster>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Heigth { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Roster> Rosters { get; set; }
    }
}
