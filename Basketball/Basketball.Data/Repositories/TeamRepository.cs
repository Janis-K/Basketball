using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ITeamRepository : IRepository<Team> { }
}
