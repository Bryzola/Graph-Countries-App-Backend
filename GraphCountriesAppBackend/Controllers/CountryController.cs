using GraphCountriesAppBackend.Interfaces;
using GraphCountriesAppBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphCountriesAppBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryData _countryData;
        public CountryController(ICountryData countryData)
        {
            _countryData = countryData;
        }

        [HttpGet]
        [Route("country-data")]
        public IActionResult GetCountriesData()
        {
            var countriesData = _countryData.GetCountriesData();

            if (countriesData != null)
            {
                return Ok(countriesData);
            }

            return NotFound("No data found for countries!");
        }

        [HttpGet]
        [Route("country-data/{countryCode}")]
        public IActionResult GetCountryData(string countryCode)
        {
            var countryData = _countryData.GetCountryData(countryCode);

            if(countryData != null) { 
                return Ok(countryData);
            }

            return Ok(null);
        }

        [HttpPost]
        [Route("country-data")]
        public IActionResult UpdateCountryData(CountryData countryData)
        {
            var countryStored = _countryData.GetCountryData(countryData.CountryCode);

            if(countryStored != null) { 
                _countryData.UpdateCountryData(countryData);
            } 
            else
            {
                if(countryData.CountryCode != null && countryData.Name != null) { 
                    _countryData.AddCountryData(countryData);
                } else
                {
                    return BadRequest("Could not find country code and name!");
                }
            }

            return Ok(countryData);
        }

        [HttpDelete]
        [Route("country-data/{countryCode}")]
        public IActionResult DeleteCountryData(string countryCode)
        {
            var countryStored = _countryData.GetCountryData(countryCode);

            if (countryStored != null)
            {
                _countryData.DeleteCountryData(countryStored);
                return Ok();
            }

            return NotFound($"Country with code '{countryCode}' was not found!");
        }
    }
}
