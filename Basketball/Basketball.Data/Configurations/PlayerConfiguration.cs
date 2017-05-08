using System.Data.Entity.ModelConfiguration;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class PlayerConfiguration : EntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
        {
            ToTable("Players");
            Property(g => g.FirstName).IsRequired().HasMaxLength(50);
            Property(g => g.LastName).IsRequired().HasMaxLength(50);
            Property(g => g.NationalityId).IsRequired();
            Property(g => g.Heigth).IsRequired();
            Property(g => g.PositionId).IsRequired();
        }
    }
}
