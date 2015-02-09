using System;

using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;

namespace IOU.Exchange
{
    public static class ExchangeServicesLocator
    {
        private const ExchangeVersion Version = ExchangeVersion.Exchange2010_SP2;

        private static readonly Lazy<ExchangeService> LazyExchangeService;

        private static readonly Lazy<AutodiscoverService> LazyAutodiscoverService;

        static ExchangeServicesLocator()
        {
            LazyExchangeService = new Lazy<ExchangeService>(CreateExchangeService);
            LazyAutodiscoverService = new Lazy<AutodiscoverService>(CreateAutodiscoverService);
        }

        private static ExchangeService CreateExchangeService()
        {
            var service = new ExchangeService(Version) { UseDefaultCredentials = true };
            service.AutodiscoverUrl(Configuration.GetEmailAddress());
            return service;
        }

        private static AutodiscoverService CreateAutodiscoverService()
        {
            return new AutodiscoverService(Version) { UseDefaultCredentials = true };
        }

        public static ExchangeService GetExchangeService()
        {
            return LazyExchangeService.Value;
        }

        public static AutodiscoverService GetAutodiscoverService()
        {
            return LazyAutodiscoverService.Value;
        }
    }
}