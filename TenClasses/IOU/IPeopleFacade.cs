namespace IOU
{
    public interface IPeopleFacade
    {
        BunchOfPeople FindByName(string name);

        Person GetMe();
    }
}

