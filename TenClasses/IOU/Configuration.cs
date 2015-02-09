using System.Configuration;
using System;

namespace IOU
{
    public static class Configuration
    {
        static Configuration()
        {
            EmailAddress = GetValue("EmailAddress");

            if (string.IsNullOrEmpty(EmailAddress))
            {
                Environment.Exit(-1);
            }
        }

        static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings [key];
        }

        public static string EmailAddress { get; private set; }
    }
}

