namespace Basketball.Models.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public int HTeam_1Q { get; set; }

        public int ATeam_1Q { get; set; }

        public int HTeam_2Q { get; set; }

        public int ATeam_2Q { get; set; }

        public int HTeam_3Q { get; set; }

        public int ATeam_3Q { get; set; }

        public int HTeam_4Q { get; set; }

        public int ATeam_4Q { get; set; }

        public int HTeam_1O { get; set; }

        public int ATeam_1O { get; set; }

        public int HTeam_2O { get; set; }

        public int ATeam_2O { get; set; }

        public int HTeam_3O { get; set; }

        public int ATeam_3O { get; set; }

        public int HTeam_4O { get; set; }

        public int ATeam_4O { get; set; }

        public int HTeam_5O { get; set; }

        public int ATeam_5O { get; set; }
    }
}
