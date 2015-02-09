using Microsoft.Exchange.WebServices.Data;
using System.Linq;
using System.Collections.Generic;

namespace IOU.Exchange
{
    public class ExchangePeopleFacade : IPeopleFacade
    {
        readonly ExchangeService service = ExchangeServiceLocator.Get();

        public IEnumerable<Person> FindByName(string name)
        {
            NameResolutionCollection resolutions = service.ResolveName(name);
            IEnumerable<Person> humans = resolutions.Select(CreatePerson);
            return humans.ToArray();
        }

        static Person CreatePerson(NameResolution nameResolution)
        {
            string name = nameResolution.Mailbox.Name;
            string emailAddress = nameResolution.Mailbox.Address;

            return new Person(name, emailAddress);
        }
    }
}

