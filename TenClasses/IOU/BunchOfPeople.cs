using System.Collections.Generic;

namespace IOU
{
    public class BunchOfPeople : List<Person>
    {
        public BunchOfPeople(IEnumerable<Person> people)
            : base(people)
        {
        }

        public static BunchOfPeople FindByName(string name)
        {
            return ServiceLocator.PeopleFacade.FindByName(name);
        }

        public Person PickPerson()
        {
            IPresenter presenter = ServiceLocator.Presenter;
            presenter.DisplayPeople(this);

            int index = presenter.GetIndexOfSelectedPerson();
            return this[index];
        }
    }
}
