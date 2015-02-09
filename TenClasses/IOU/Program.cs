namespace IOU
{
    class Program
    {
        static void Main()
        {
            Person me = Person.GetMe();
            me.Greet();
            Person person = me.WhoMadeYourDay();
            person.YouMadeMyDay();
        }
    }
}
