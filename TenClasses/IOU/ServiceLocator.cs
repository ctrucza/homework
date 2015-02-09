using IOU.Exchange;

namespace IOU
{
    public static class ServiceLocator
    {
        public static IPeopleFacade PeopleFacade = new ExchangePeopleFacade();

        public static IPresenter Presenter = new Presenter();

        // TODO: Add EmailServer
        // TODO: Add EventsStorage
    }
}

