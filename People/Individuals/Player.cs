using System;
using System.Collections.Generic;
using System.Linq;

public class Player : Person
{

    public Player(string firstName, string lastName, Culture culture, Traits traits, Knowledge knowledge) : base(firstName, lastName, culture, traits, knowledge)
    {

    }

    public override Message GenerateMessage(Person recipient)
    {
        Console.WriteLine(Name + " is preparing to talk to " + recipient.Name);
        MessageType type = ChooseMessageType();
        Topic topic = ChooseTopic();
        return new Message
        {
            Type = type,
            Topic = topic,
            Speaker = this,
            Recipient = recipient,
            Information = 1f,
        };
    }

    public override void ReceiveMessage(Message message)
    {
        if (message.Type == MessageType.Closing)
        {
            Console.WriteLine("Conversation is over");
            return;
        }

        Message response = GenerateMessage(message.Speaker);
        DeliverMessage(response);
    }

    public override void DeliverMessage(Message message)
    {
        Console.WriteLine(message.ToString());
        message.Recipient.ReceiveMessage(message);
    }

    Topic ChooseTopic()
    {
        return ChooseFromList<Topic>(Topic.GetAll<Topic>(), "Choose a topic: ");
    }

    MessageType ChooseMessageType()
    {
        return ChooseFromList<MessageType>(MessageType.GetAll<MessageType>(), "Choose a message type: ");
    }

    T ChooseFromList<T>(IEnumerable<T> collection, string prompt)
    {
        int id = 0;
        foreach (T element in collection)
        {
            Console.WriteLine(id + 1 + ". " + element.ToString());
            id++;
        }
        int chosen = -1;
        while (chosen < 0 || chosen >= id)
        {
            Console.Write(prompt);
            chosen = Convert.ToInt32(Console.ReadLine()) - 1;
        }
        return collection.ElementAt<T>(chosen);
    }
}