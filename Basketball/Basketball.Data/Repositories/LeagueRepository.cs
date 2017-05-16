using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class LeagueRepository : RepositoryBase<League>, ILeagueRepository
    {
        public LeagueRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface ILeagueRepository
    {

    }
}
