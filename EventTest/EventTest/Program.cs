
using EventTest;

Console.WriteLine("Program started");

ISubscription heatsubscription = new HeatwaveSubscription();
ISubscription coldsubscription = new ColdwaveSubscription();
ISubscription stormsubscription = new StormSubscription();
ISubscription emailsubscription = new EmailSubscription();

WeatherAlertSystem Weather_Kolkata = new WeatherAlertSystem();
WeatherAlertSystem Weather_Chennai = new WeatherAlertSystem();
WeatherAlertSystem Weather_Kashmir = new WeatherAlertSystem();
WeatherAlertSystem Weather_Delhi = new WeatherAlertSystem();


// Subscribe to events
heatsubscription.AddSubscriber(new WeatherAlertSystem[] { Weather_Kolkata, Weather_Chennai, Weather_Delhi });
coldsubscription.AddSubscriber(new WeatherAlertSystem[] { Weather_Kashmir, Weather_Delhi });
stormsubscription.AddSubscriber(new WeatherAlertSystem[] { Weather_Kolkata, Weather_Kashmir, Weather_Chennai, Weather_Delhi });
emailsubscription.AddSubscriber(new WeatherAlertSystem[] { Weather_Kolkata, Weather_Delhi, Weather_Chennai });

// Simulate weather changes

Console.WriteLine("\n\nKolkata Normal Weather Test");
Weather_Kolkata.CurrentWeather = new WeatherData(10, 30);

Console.WriteLine("\n\nKolkata Stormy Test");
Weather_Kolkata.CurrentWeather = new WeatherData(70, 30);

Console.WriteLine("\n\nChennai Heat Test");
Weather_Chennai.CurrentWeather = new WeatherData(20, 50);

Console.WriteLine("\n\nDelhi Storm and Cold Test");
Weather_Delhi.CurrentWeather = new WeatherData(80, 3);

Console.WriteLine("\n\nKashmir Storm Test");
Weather_Kashmir.CurrentWeather = new WeatherData(85, 7);

// Unsubscribe email form Delhi and Chennai
emailsubscription.RemoveSubscriber(new WeatherAlertSystem[] { Weather_Delhi, Weather_Chennai });

Console.WriteLine("\n\nChennai After unsubscribe - Heat Test");
Weather_Chennai.CurrentWeather = new WeatherData(20, 50);

Console.WriteLine("\n\nKolkata after unsubscribe - Heat Test");
Weather_Kolkata.CurrentWeather = new WeatherData(20, 50);







