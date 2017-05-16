using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class LeagueSeasonConfiguration : EntityTypeConfiguration<LeagueSeason>
    {
        public LeagueSeasonConfiguration()
    {
        ToTable("LeagueSeasons");
        Property(g => g.LeagueId).IsRequired();
        Property(g => g.SeasonId).IsRequired();
    }
}
}
