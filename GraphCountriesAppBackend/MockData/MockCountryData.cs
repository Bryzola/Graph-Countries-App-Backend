using GraphCountriesAppBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphCountriesAppBackend.Interfaces
{
    public class MockCountryData : ICountryData
    {
        private List<CountryData> countriesData = new List<CountryData>(){};

        public List<CountryData> GetCountriesData()
        {
            return countriesData;
        }

        public CountryData GetCountryData(string countryCode)
        {
            return countriesData.Where(x => x.CountryCode == countryCode).DefaultIfEmpty(null).Single();
        }

        public CountryData AddCountryData(CountryData countryData)
        {
            countriesData.Add(countryData);

            return countryData;
        }

        public CountryData UpdateCountryData(CountryData countryData)
        {
            CountryData updatingCountryData = GetCountryData(countryData.CountryCode);

            updatingCountryData.Capital = countryData.Capital;
            updatingCountryData.Region = countryData.Region;
            updatingCountryData.Flag = countryData.Flag;
            updatingCountryData.Currency = countryData.Currency;
            updatingCountryData.Population = countryData.Population;
            updatingCountryData.Area = countryData.Area;
            updatingCountryData.TopLevelDomain = countryData.TopLevelDomain;

            return updatingCountryData;
        }

        public void DeleteCountryData(CountryData countryData)
        {
            countriesData.Remove(countryData);
        }
    }
}
