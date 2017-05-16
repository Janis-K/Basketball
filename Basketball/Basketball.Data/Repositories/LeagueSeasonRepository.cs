using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    class LeagueSeasonRepository : RepositoryBase<LeagueSeason>, ILeagueSeasonRepository
    {
        public LeagueSeasonRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ILeagueSeasonRepository : IRepository<LeagueSeason>
    {

    }
}
