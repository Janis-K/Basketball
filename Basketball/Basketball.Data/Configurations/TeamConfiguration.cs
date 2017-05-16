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
            HasRequired(g => g.TeamCountry).WithMany(s => s.Teams).HasForeignKey(x => x.CountryId);
        }
    }
}
