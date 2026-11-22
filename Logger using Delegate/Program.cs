using System;
using System.IO;

public class Logger
{
    public delegate void LogAction(string Message);

    private LogAction _LogAction;


    public Logger(LogAction Action)
    {
        _LogAction = Action;
    }


    public void Log(string Message)
    {
        _LogAction(Message);
    }
}


public class Program
{
    public static void LogToScreen(string Message)
    {
        Console.WriteLine(Message);
    }

    public static void LogToFile(string Message)
    {
        string fileName = "log.txt";
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            writer.WriteLine(Message);
        }
    }

    public static void LogToDatabase(string Message)
    {
        //write the code to log the message in the database .

        Console.Write(Message);
    }

    static void Main(string[] args)
    {
        Logger ScreenLogger = new Logger(LogToScreen);
        Logger FileLogger = new Logger(LogToFile);
        Logger DBLogger = new Logger(LogToDatabase);


        ScreenLogger.Log("This message will be displayed on the screen.");
        FileLogger.Log("This message will be logged to a file.");
        DBLogger.Log("This message will be logged to database.");



        // You can easily switch between logging to the screen or a file by changing the Logger instance.


        Console.ReadLine();

    }
}