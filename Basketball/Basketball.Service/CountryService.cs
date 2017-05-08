using System.Collections.Generic;
using Basketball.Data.Infrastructure;
using Basketball.Data.Repositories;
using Basketball.Models.Models;

namespace Basketball.Service
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountry(string name);
        void CreateCountry(Country country);
        void SaveCountry();
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Country> GetCountries()
        {
            return countryRepository.GetAll();
        }

        public Country GetCountry(int id)
        {
            return countryRepository.GetById(id);
        }

        public Country GetCountry(string name)
        {
            return countryRepository.GetCountryByName(name);
        }

        public void CreateCountry(Country country)
        {
            countryRepository.Add(country);
        }

        public void SaveCountry()
        {
            unitOfWork.Commit();
        }
    }
}
