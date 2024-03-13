using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using System.Text.Json;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using WeatherAPI.Logic;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CountryLogic _countryLogic;

        public WeatherForecastController(CountryLogic countryLogic)
        {
            _countryLogic = countryLogic;
    }
        [HttpGet("country")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            var countries = await _countryLogic.GetCountries();
            return Ok(countries);
        }
        [HttpGet("count")]
        public async Task<Object> GetCountCountry()
        {
            var count = await _countryLogic.GetCountCountry();
            var message = $"There are {count} countries in this world!";
            return Ok(new { Message = message });
        }
        [HttpGet("SearchCountry")]
        public async Task<ActionResult>GetSpecificCountry(string name)
        {
            var country = await _countryLogic.GetSpecificCountry(name);
            return Ok(country);
        }


    }
}