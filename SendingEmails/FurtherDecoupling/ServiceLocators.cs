using FurtherDecoupling.Emails;

namespace FurtherDecoupling
{
    public static class EmailServerLocator
    {
        public static EmailServer Instance = new DefaultEmailServer();
    }
}

