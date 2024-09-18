
Console.WriteLine("Hello, World!");

WriteLog("This is a text");

WriteLog("This is a text 2");

WriteLog("This is a text 3");

WriteLog("This is a text 4");



static void WriteLog(string Message)
{
    string LogFilePath = @"C:\Manas\FilePath\";
    string LogFileName = "DMLogs_"+ DateTime.Now.ToString("yyyyMMdd") + ".log";
    string FullLogFilePath = Path.Join(LogFilePath, LogFileName);

    // check if folder exists, if not then create it.
    if (!Directory.Exists(LogFilePath)) Directory.CreateDirectory(LogFilePath);

    // Check if logfile exists, if no then create new logfile. if yes then append to it.
    using (StreamWriter sw = File.AppendText(FullLogFilePath))
    {
        sw.WriteLine( DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "  Message: " + Message);
    }

}
