using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class SeasonConfiguration : EntityTypeConfiguration<Season>
    {
        public SeasonConfiguration()
        {
            ToTable("Seasons");
            Property(g => g.SeasonName).IsRequired();
        }
    }
}
