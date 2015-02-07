using IOU.Exchange;

namespace IOU
{
    public static class ServiceLocator
    {
        public static IHumansStorage HumansStorage = new ExchangeHumansStorage();
    }
}

