using System;
using System.Collections.Generic;
using System.Linq;

public class Person : ICommunicator
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Name => FirstName + " " + LastName;
    public Topic PreviousTopic { get; set; }
    public BasicPsyche Psyche { get; private set; }
    public IPersonDriver Driver { get; set; }
    public Conversation CurrentConversation { get; set; }

    public Person(string firstName, string lastName, BasicPsyche psyche)
    {
        FirstName = firstName;
        LastName = lastName;
        Psyche = psyche;
    }

    public Message GenerateMessage(Person receiver)
    {
        Console.WriteLine(Name + " is preparing to talk to " + receiver.Name);
        return Driver.GenerateMessage(receiver);
    }
    public void ReceiveMessage(Message message)
    {
        /*
        if (message.Type == MessageType.Closing)
        {
            Console.WriteLine("Conversation is over");
            return;
        }
        */
        if (CurrentConversation == null) CurrentConversation = new Conversation();
        CurrentConversation.History.Add(message);

        // todo: reject messages from other conversations somehow
        Message response = GenerateMessage(message.Speaker);
        DeliverMessage(response);
    }

    public void DeliverMessage(Message message)
    {
        Console.WriteLine(message.ToString());
        message.Receiver.ReceiveMessage(message);
        CurrentConversation.History.Add(message);
    }
}