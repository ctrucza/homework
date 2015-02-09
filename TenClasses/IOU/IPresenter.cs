namespace IOU
{
    public interface IPresenter
    {
        void SayHi(string name);

        string GetNameOfWhoMadeYourDay();

        void DisplayPeople(BunchOfPeople people);

        int GetIndexOfSelectedPerson();
    }
}
