using System;
using System.IO;

namespace Logsystem
{
    public static class Logger
    {
        private static string logFilePath = @"C:\Path\to\logs.txt";

        private static readonly object lockObj = new object();


        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogSuccess(string message)
        {
            Log("SUCCESS", message);
        }


        public static void LogError(string message)
        {
            Log("ERROR", message);
        }


        private static void Log(string level, string message)
        {
            lock (lockObj)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(logFilePath, true))
                    {
                        sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Khata Dar Neveshtane Log: " + ex.Message);
                }
            }
        }
    }
}