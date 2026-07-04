namespace HttpServer
{
    public class WeatherForecastListResponse
    {
         public List<WeatherForecast> WeatherForecast { get; set; }

    }
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
