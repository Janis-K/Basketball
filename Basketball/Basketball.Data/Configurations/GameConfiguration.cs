using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            ToTable("Games");
            HasRequired(x => x.AwayTeam).WithMany(s => s.AwayGames).HasForeignKey(x => x.AwayTeamId);
            HasRequired(x => x.HomeTeam).WithMany(s => s.HomeGames).HasForeignKey(x => x.HomeTeamId);
        }
    }
}
