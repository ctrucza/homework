using System.Collections.Generic;


namespace IOU
{
    public interface IHumansStorage
    {
        IEnumerable<Human> FindByName(string name);
    }
}

