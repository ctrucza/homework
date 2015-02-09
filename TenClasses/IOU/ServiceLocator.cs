using IOU.Exchange;

namespace IOU
{
    public static class ServiceLocator
    {
        public static IPeopleFacade HumansStorage = new ExchangePeopleFacade();

        // TODO: Add EmailServer
        // TODO: Add EventsStorage
    }
}

