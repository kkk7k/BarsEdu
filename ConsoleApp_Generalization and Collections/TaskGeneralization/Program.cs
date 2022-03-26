
string path = @"C:\Users\Admin\Desktop\logFile.txt";

//string
LocalFileLogger<string> localFileLoggerString = new LocalFileLogger<string>(path);

localFileLoggerString.LogInfo("Info message");
localFileLoggerString.LogWarning("Warning message");
Exception? ex1 = null;
localFileLoggerString.LogError("Error message", ex1);

//int
LocalFileLogger<int> localFileLoggerInt = new LocalFileLogger<int>(path);

localFileLoggerInt.LogInfo("Info message");
localFileLoggerInt.LogWarning("Warning message");
Exception? ex2 = null;
localFileLoggerInt.LogError("Error message", ex2);

interface ILogger
{
    void LogInfo(string message);
    
    void LogWarning(string message);

    void LogError(string message, Exception ex);
}

class LocalFileLogger<T> : ILogger
{
    private string Path;
    public LocalFileLogger(string path)
    {
        Path = path;
    }

    public void LogInfo(string message)
    {
        using (var file = new FileStream(Path, FileMode.Append))
        using (var fileWrite = new StreamWriter(file))
            fileWrite.Write($"[Info]: [{typeof(T).Name}] : {message}\n");
    }

    public void LogWarning(string message)
    {
        using (var file = new FileStream(Path, FileMode.Append))
        using (var fileWrite = new StreamWriter(file))
            fileWrite.Write($"[Warning]: [{typeof(T).Name}] : {message}\n");
    }

    public void LogError(string message, Exception? ex)
    {
        using (var file = new FileStream(Path, FileMode.Append))
        using (var fileWrite = new StreamWriter(file))
            fileWrite.Write($"[Error]: [{typeof(T).Name}] : {message}.{ex?.Message}\n");
    }
}