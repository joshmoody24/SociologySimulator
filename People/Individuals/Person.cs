using System.Collections.Generic;

public abstract class Person : ICommunicator
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Name => FirstName + " " + LastName;
    public Topic PreviousTopic { get; set; }
    public Pysche Pysche { get; private set; }
    public IPersonDriver Driver { get; private set; }
    public Conversation CurrentConversation { get; set; }

    public Person(string firstName, string lastName, Psyche psyche)
    {
        FirstName = firstName;
        LastName = lastName;
        Culture = culture;
        Values = Culture.Values.Copy();
        Traits = traits;
        Knowledge = knowledge;
    }

    public abstract Message GenerateMessage(Person recipient);
    public abstract void ReceiveMessage(Message message);
    public abstract void DeliverMessage(Message message);
}