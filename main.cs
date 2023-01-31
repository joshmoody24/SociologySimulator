using System;

class Program
{
    public static void Main(string[] args)
    {
        Person josh = PersonFactory.GenerateJosh(true);
        Person matthew = PersonFactory.GenerateMatthew(false);
        Topic topic = Topic.HeavenlyFather;
        Message greeting = josh.GenerateMessage(matthew);
        josh.DeliverMessage(greeting);
    }
}