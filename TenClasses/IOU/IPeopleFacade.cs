using System.Collections.Generic;


namespace IOU
{
    public interface IPeopleFacade
    {
        IEnumerable<Person> FindByName(string name);
    }
}

