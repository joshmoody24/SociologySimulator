using System.Collections.Generic;

public abstract class Person : ICommunicator
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Name => FirstName + " " + LastName;
    public Values Values { get; private set; }
    public Culture Culture { get; private set; }
    public Traits Traits { get; private set; }
    public Needs Needs { get; private set; }
    public HashSet<Emotion> CurrentEmotions { get; private set; }
    public Knowledge Knowledge { get; private set; }

    public Person(string firstName, string lastName, Culture culture, Traits traits, Knowledge knowledge)
    {
        FirstName = firstName;
        LastName = lastName;
        Culture = culture;
        Values = Culture.Values.Copy();
        Traits = traits;
        CurrentEmotions = new HashSet<Emotion>();
        Knowledge = knowledge;
    }

    public abstract Message GenerateMessage(Person recipient);
    public abstract void ReceiveMessage(Message message);
    public abstract void DeliverMessage(Message message);
}