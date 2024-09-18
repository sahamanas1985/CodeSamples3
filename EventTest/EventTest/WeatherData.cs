
namespace EventTest
{
    public class WeatherData
    {
        public int windspeed { get; set; }
        public int temparature { get; set; }

        public WeatherData(int WindSpeed, int Temparature)
        {
            windspeed = WindSpeed;
            temparature = Temparature;
        }
    }
}
