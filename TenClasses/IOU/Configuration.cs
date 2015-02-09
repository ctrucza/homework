using System.Configuration;
using System;

namespace IOU
{
    public static class Configuration
    {
        public static string GetEmailAddress()
        {
            string value = GetValue("EmailAddress");

            if (string.IsNullOrEmpty(value))
            {
                throw new BadConfigurationException();
            }

            return value;
        }

        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

    public class BadConfigurationException : Exception
    {
        public BadConfigurationException()
            : base(":( Bad configuration!")
        {
        }
    }
}