using Microsoft.Exchange.WebServices.Data;
using System.Linq;
using System.Collections.Generic;

namespace IOU.Exchange
{
    public class ExchangeHumansStorage : IHumansStorage
    {
        ExchangeService service = ExchangeServiceLocator.Get();

        public IEnumerable<Human> FindByName(string name)
        {
            NameResolutionCollection resolutions = service.ResolveName(name);
            IEnumerable<Human> humans = resolutions.Select(ConvertToHuman);
            return humans.ToArray();
        }

        static Human ConvertToHuman(NameResolution nameResolution)
        {
            string name = nameResolution.Mailbox.Name;
            string emailAddress = nameResolution.Mailbox.Address;

            return new Human(name, emailAddress);
        }
    }
}

