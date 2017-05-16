using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class LeagueConfiguration : EntityTypeConfiguration<League>
    {
        public LeagueConfiguration()
        {
            ToTable("Leagues");
            Property(g => g.LeagueName).IsRequired();
        }
    }
}
