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

        readonly string myAddress = Configuration.EmailAddress;

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
            return new Person(GetMyDisplayName(), myAddress);
        }

        private string GetMyDisplayName()
        {
            const UserSettingName Key = UserSettingName.UserDisplayName;

            GetUserSettingsResponse response = autodiscoverService.GetUserSettings(myAddress, Key);
            return response.Settings[Key].ToString();
        }
    }
}

