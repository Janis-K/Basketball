using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.Data.Infrastructure;
using Basketball.Data.Repositories;
using Basketball.Models.Models;

namespace Basketball.Service
{
    public interface IGameService
    {
        IEnumerable<Game> GetCountries();
        Game GetCountry(int id);
        Game GetCountry(string name);
        void CreateGame(Game game);
        void SaveCountry();
    }

    public class GameService : IGameService
    {
#pragma warning disable CS0649 // Field 'GameService.gameRepository' is never assigned to, and will always have its default value null
        private readonly IGameRepository gameRepository;
#pragma warning restore CS0649 // Field 'GameService.gameRepository' is never assigned to, and will always have its default value null
#pragma warning disable CS0169 // The field 'GameService.unitOfWork' is never used
        private readonly IUnitOfWork unitOfWork;
#pragma warning restore CS0169 // The field 'GameService.unitOfWork' is never used

        public void CreateGame(Game game)
        {
            gameRepository.Add(game);
        }

        public IEnumerable<Game> GetCountries()
        {
            throw new NotImplementedException();
        }

        public Game GetCountry(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetCountry(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveCountry()
        {
            throw new NotImplementedException();
        }
    }
}
