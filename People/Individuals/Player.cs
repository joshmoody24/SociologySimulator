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
            Quality = 1f,
        };
    }

    public override void ReceiveMessage(Message message)
    {
        if (message.Type == MessageType.Closing)
        {
            Console.WriteLine("Conversation is over");
            return;
        }
        PreviousTopic = message.Topic;
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
        IEnumerable<Topic> options = Topic.SimilarTopics(PreviousTopic, 5, 0.1);
        return ChooseFromList<Topic>(options, "Topics");
    }

    MessageType ChooseMessageType()
    {
        return ChooseFromList<MessageType>(MessageType.GetAll<MessageType>(), "Message Types");
    }

    T ChooseFromList<T>(IEnumerable<T> collection, string prompt)
    {
        int id = 0;
        int chosen = -1;
        while (chosen < 0 || chosen >= id)
        {
            Console.WriteLine(prompt);
            foreach (T element in collection)
            {
                Console.WriteLine(id + 1 + ". " + element.ToString());
                id++;
            }
            Console.Write("Enter a number: ");
            if (!int.TryParse(Console.ReadLine(), out chosen)) continue;
            chosen -= 1;
        }
        Console.WriteLine(collection.ElementAt<T>(chosen).ToString() + " selected");
        return collection.ElementAt<T>(chosen);
    }
}