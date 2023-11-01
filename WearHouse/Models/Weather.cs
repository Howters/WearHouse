
namespace WearHouse.Models
{
    public class Weather
    {
        public string Cod { get; set; }
        public string CityName { get; set; }
        public string TempMin { get; set; }
        public string TempMax { get; set; }
        public string Temp { get; set; }
        public string Wicon { get; set; }
        public string Description { get; set; }
        public string TimeStamp { get; set; }
        public string Country { get; set; }
        public string WindDirection { get; set; }
        public string CardinalDirection { get; set; }
        public string Speed { get; set; }
        public string Pop { get; set; }
        public List<Weather> WeatherList { get; set; }
    }
}