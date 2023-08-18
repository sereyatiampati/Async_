using System;

namespace AsyncJob.Helpers
{
    public static class ConsoleHelper
    {
        public static string ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        // Other console-related helper methods...
    }
}
