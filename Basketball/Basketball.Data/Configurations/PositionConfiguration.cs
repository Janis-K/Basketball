using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            ToTable("Positions");
            Property(g => g.PositionName).IsRequired().HasMaxLength(50);
        }
    }
}
