

namespace EventTest
{
    interface ISubscription
    {
        public void AddSubscriber(WeatherAlertSystem[] weatherAlertSystem);
        public void RemoveSubscriber(WeatherAlertSystem[] weatherAlertSystem);
        public void Action(object? sender, WeatherChangedEventArgs e);
    }

    public class HeatwaveSubscription : ISubscription
    {
        public void AddSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach(WeatherAlertSystem was in weatherAlertSystem)
                was.HeatWaveTriggered += Action;
        }

        public void RemoveSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.HeatWaveTriggered -= Action;
        }

        public void Action(object? sender, WeatherChangedEventArgs e)
        {
            Console.WriteLine($"Heatwave Alert Triggered - Temparature :" + e.WeatherCondition.temparature);
        }
        
    }

    public class ColdwaveSubscription : ISubscription
    {
        public void AddSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.ColdWaveTriggered += Action;
        }

        public void RemoveSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.ColdWaveTriggered -= Action;
        }

        public void Action(object? sender, WeatherChangedEventArgs e)
        {
            Console.WriteLine($"Coldwave Alert Triggered - Temparature :" + e.WeatherCondition.temparature);
        }
    }


    public class StormSubscription : ISubscription
    {
        public void AddSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.StormTriggered += Action;
        }

        public void RemoveSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.StormTriggered -= Action;
        }

        public void Action(object? sender, WeatherChangedEventArgs e)
        {
            Console.WriteLine($"Storm Alert Triggered - Windspeed :" + e.WeatherCondition.windspeed);
        }
    }


    public class EmailSubscription : ISubscription
    {
        public void AddSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.EmailTriggered += Action;
        }

        public void RemoveSubscriber(WeatherAlertSystem[] weatherAlertSystem)
        {
            foreach (WeatherAlertSystem was in weatherAlertSystem)
                was.EmailTriggered -= Action;
        }

        public void Action(object? sender, WeatherChangedEventArgs e)
        {
            Console.WriteLine($"Email Triggered - Temp :" + e.WeatherCondition.temparature + ", Windspeed : " + e.WeatherCondition.windspeed);
        }
    }

}
