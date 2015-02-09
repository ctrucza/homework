using System;
using Microsoft.Exchange.WebServices.Data;

namespace IOU.Exchange
{
    public static class ExchangeServiceLocator
    {
        static readonly Lazy<ExchangeService> lazyService;

        static ExchangeServiceLocator()
        {
            lazyService = new Lazy<ExchangeService>(CreateService);
        }

        static ExchangeService CreateService()
        {
            var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            service.Url = new Uri(Configuration.EwsUrl);
            service.UseDefaultCredentials = true;
            return service;
        }

        public static ExchangeService Get()
        {
            return lazyService.Value;
        }
    }
}

