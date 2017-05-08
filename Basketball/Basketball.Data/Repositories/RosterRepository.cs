using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class RosterRepository : RepositoryBase<Roster>, IRosterRepository
    {
        public RosterRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IRosterRepository : IRepository<Roster> { }
}
