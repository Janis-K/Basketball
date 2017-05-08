using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IGameRepository : IRepository<Game> { }
}
