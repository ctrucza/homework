using System.Configuration;
using System;

namespace IOU
{
    public static class Configuration
    {
        static Configuration()
        {
            Name = GetValue("Name");
            EmailAddress = GetValue("EmailAddress");
            EwsUrl = GetValue("EwsUrl");
        }

        static string GetValue(string key)
        {
            string value = ConfigurationManager.AppSettings [key];

            if (value == null)
            {
                ComplainAndStop(key);
            }

            return value;
        }

        static void ComplainAndStop(string key)
        {
            Console.WriteLine("Configuration entry '{0}' is missing.", key);
            Environment.Exit(-1);
        }

        public static string Name { get; private set; } 

        public static string EmailAddress { get; private set; }

        public static string EwsUrl { get; private set; }
    }
}

