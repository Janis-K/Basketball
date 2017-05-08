using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IPlayerRepository : IRepository<Player> { }
}
