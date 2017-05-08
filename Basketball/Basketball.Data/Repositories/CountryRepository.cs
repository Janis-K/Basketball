using System.Linq;
using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Country GetCountryByName(string countryName)
        {
            var country = this.DbContext.Countries.FirstOrDefault(c => c.CountryName == countryName);

            return country;
        }
    }

    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountryByName(string countryName);
    }
}
