using System.Collections.Generic;
using GraphCountriesAppBackend.Models;

namespace GraphCountriesAppBackend.Interfaces
{
    public interface ICountryData
    {
        List<CountryData> GetCountriesData();
        CountryData GetCountryData(string countryCode);
        CountryData AddCountryData(CountryData countryData);
        CountryData UpdateCountryData(CountryData countryData);
        void DeleteCountryData(CountryData countryData);
    }
}
