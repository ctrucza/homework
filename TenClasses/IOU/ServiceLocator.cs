using IOU.Exchange;

namespace IOU
{
    public static class ServiceLocator
    {
        public static IPeopleFacade PeopleFacade = new ExchangePeopleFacade();

        public static IMailServer MailServer = new ExchangeMailServer();

        public static IPresenter Presenter = new Presenter();

        // TODO: Add EventsStorage
    }
}

