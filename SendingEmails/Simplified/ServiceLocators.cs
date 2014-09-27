using Simplified.Emails;

namespace Simplified
{
    public static class EmailServerLocator
    {
        public static EmailServer Instance = new DefaultEmailServer();
    }

    public static class AddressbookLocator
    {
        public static Addressbook Instance = new DefaultAddressbook();
    }
}

