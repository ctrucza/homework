using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Linq;
using System.Collections.Generic;

namespace IOU.Exchange
{
    public class ExchangePeopleFacade : IPeopleFacade
    {
        public BunchOfPeople FindByName(string name)
        {
            ExchangeService exchangeService = ExchangeServicesLocator.GetExchangeService();
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
            return new Person(GetMyDisplayName(), GetMyAddress());
        }

        private string GetMyAddress()
        {
            return Configuration.GetEmailAddress();
        }

        private string GetMyDisplayName()
        {
            const UserSettingName Key = UserSettingName.UserDisplayName;

            AutodiscoverService autodiscoverService = ExchangeServicesLocator.GetAutodiscoverService();
            GetUserSettingsResponse response = autodiscoverService.GetUserSettings(GetMyAddress(), Key);
            return response.Settings[Key].ToString();
        }
    }
}

