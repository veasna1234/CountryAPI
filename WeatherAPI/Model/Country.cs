using System.Collections.Generic;

namespace WeatherAPI.Model
{
    public class Country
    {
        public Name name { get; set; }
        public string[]? capital { get; set; }
        public Dictionary<string, string>? languages { get; set; }
        public Dictionary<string, Currency>? currencies { get; set; }
        public double[]? latlng { get; set; }
        public bool landlocked { get; set; }
        public string[]? borders { get; set; }
        public double area { get; set; }
        public string flag { get; set; }
        public Dictionary<string, Demon>? demonyms { get; set; }
        public Dictionary<string,string>? maps { get; set; }
        public double population { get; set; }
        public Car car { get; set; }
        public string[] continents { get; set; }
        public string[] timezones { get; set; }
        public Translation translations { get; set; }
    }

    public class Name
    {
        public string? official { get; set; } = string.Empty;
        public string? common { get; set; } = string.Empty;
        // Add other properties as needed
    }
    public class Currency
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }
    public class Demon
    {
        public string f { get; set; }
        public string m { get; set; }

    }
    public class Car
    {
        public List<string> signs { get; set; }
        public string side { get; set; }
    }
    public class Translation
    {
        public Name ara { get; set; }
        public Name bre { get; set; }
        public Name jpn { get; set; }
        public Name zho { get; set; }
    }
}
