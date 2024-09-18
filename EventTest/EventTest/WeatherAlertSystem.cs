
namespace EventTest
{
    public class WeatherAlertSystem
    {
        public event EventHandler<WeatherChangedEventArgs> HeatWaveTriggered;
        public event EventHandler<WeatherChangedEventArgs> ColdWaveTriggered;
        public event EventHandler<WeatherChangedEventArgs> StormTriggered;
        public event EventHandler<WeatherChangedEventArgs> EmailTriggered;

        private WeatherData currentWeather;

        public WeatherData CurrentWeather
        {
            get
            {
                return currentWeather;
            }
            set
            {
                currentWeather = value;                

                if (currentWeather.temparature >= 40)
                {
                    //trigger Heatwave event
                    OnHeatWave(new WeatherChangedEventArgs { WeatherCondition = currentWeather });
                }
                if(currentWeather.temparature < 5)
                {
                    // Trigger extreeme cold event
                    OnColdWave(new WeatherChangedEventArgs { WeatherCondition = currentWeather });
                }
                if (currentWeather.windspeed > 60)
                {
                    // Trigger storm event
                    OnStorm(new WeatherChangedEventArgs { WeatherCondition = currentWeather });                    
                }

                // Trigger Email event
                OnEmail(new WeatherChangedEventArgs { WeatherCondition = currentWeather });

            }

        }

        protected virtual void OnHeatWave(WeatherChangedEventArgs e)
        {
            HeatWaveTriggered?.Invoke(this, e);
        }

        protected virtual void OnColdWave(WeatherChangedEventArgs e)
        {
            ColdWaveTriggered?.Invoke(this, e);
        }

        protected virtual void OnStorm(WeatherChangedEventArgs e)
        {
            StormTriggered?.Invoke(this, e);
        }

        protected virtual void OnEmail(WeatherChangedEventArgs e)
        {
            EmailTriggered?.Invoke(this, e);
        }
    }


    public class WeatherChangedEventArgs : EventArgs
    {
        public WeatherData WeatherCondition { get; set; }
    }

}
