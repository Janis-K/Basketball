using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class RosterConfiguration : EntityTypeConfiguration<Roster>
    {
        public RosterConfiguration()
        {
            ToTable("Rosters");
            Property(g => g.TeamId).IsRequired();
            Property(g => g.SeasonId).IsRequired();
        }
    }
}
