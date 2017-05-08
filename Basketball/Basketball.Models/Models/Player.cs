using System.Collections.Generic;

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

        public Position Position { get; set; }

        public int NationalityId { get; set; }

        public Country Nationality { get; set; }

        public int NaturalizedId { get; set; }

        public Country Naturalized { get; set; }

        public virtual ICollection<Roster> Rosters { get; set; }
    }
}
