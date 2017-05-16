using System;

namespace Basketball.Models.Models
{
    public class Performance
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        public int TwoPtfgm { get; set; }

        public int TwoPtfga { get; set; }

        public int ThreePtfgm { get; set; }

        public int ThreePtfga { get; set; }

        public int Ftm { get; set; }

        public int Fta { get; set; }

        public int Dreb { get; set; }

        public int Oreb { get; set; }

        public int As { get; set; }

        public int To { get; set; }

        public int St { get; set; }
        
        public int Bl { get; set; }

        public int Fo { get; set; }

        public int Foa { get; set; }

        public TimeSpan Time { get; set; }

        public bool Starter { get; set; }

        public int PlusMinus { get; set; }
    }
}
