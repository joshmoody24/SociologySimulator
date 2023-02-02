using System;
using System.Collections.Generic;
using System.Linq;

public class Npc : Person
{

    public Npc(string firstName, string lastName, Culture culture, Traits traits, Knowledge knowledge) : base(firstName, lastName, culture, traits, knowledge)
    {

    }

    public override Message GenerateMessage(Person recipient)
    {
        return new Message
        {
            Speaker = this,
            Recipient = recipient,
            Topic = RandomFromList<Topic>(Topic.SimilarTopics(PreviousTopic, 5, 0.1)),
            Type = RandomFromList<MessageType>(MessageType.GetAll<MessageType>()),
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

    T RandomFromList<T>(IEnumerable<T> collection)
    {
        Random rand = new Random();
        int random = rand.Next(0, collection.Count());
        return collection.ElementAt<T>(random);
    }
}