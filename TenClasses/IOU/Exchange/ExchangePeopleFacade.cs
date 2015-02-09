using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Linq;
using System.Collections.Generic;

namespace IOU.Exchange
{
    public class ExchangePeopleFacade : IPeopleFacade
    {
        readonly ExchangeService exchangeService = ExchangeServicesLocator.GetExchangeService();

        readonly AutodiscoverService autodiscoverService = ExchangeServicesLocator.GetAutodiscoverService();

        public BunchOfPeople FindByName(string name)
        {
            NameResolutionCollection resolutions = exchangeService.ResolveName(name);
            IEnumerable<Person> people = resolutions.Select(CreatePerson);

            return new BunchOfPeople(people);
        }

        static Person CreatePerson(NameResolution nameResolution)
        {
            string name = nameResolution.Mailbox.Name;
            string emailAddress = nameResolution.Mailbox.Address;

            return new Person(name, emailAddress);
        }

        public Person GetMe()
        {
            string address = Configuration.EmailAddress;
            GetUserSettingsResponse response = autodiscoverService.GetUserSettings(address, UserSettingName.UserDisplayName);
            string name = response.Settings[UserSettingName.UserDisplayName].ToString();

            return new Person(name, address);
        }
    }
}

