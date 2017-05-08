using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class PerformanceConfiguration : EntityTypeConfiguration<Performance>
    {
        public PerformanceConfiguration()
        {
            ToTable("Performances");
            Property(g => g.PlayerId).IsRequired();
            Property(g => g.GameId).IsRequired();
        }
    }
}
