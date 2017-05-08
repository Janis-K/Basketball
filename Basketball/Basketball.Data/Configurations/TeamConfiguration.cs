using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            ToTable("Teams");
            Property(g => g.TeamName).IsRequired();
            Property(g => g.City).IsRequired();
            Property(g => g.CountryId).IsRequired();
        }
    }
}
