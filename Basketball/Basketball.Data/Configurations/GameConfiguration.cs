using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            ToTable("Games");
            Property(g => g.HomeTeamId).IsRequired();
            Property(g => g.AwayTeamId).IsRequired();
        }
    }
}
