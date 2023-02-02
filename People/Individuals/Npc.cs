using System;
using System.Collections.Generic;
using System.Linq;

public class Npc : IPersonDriver
{
    Person Person { get; }
    public Npc(Person person)
    {
        Person = person;
    }

    public Message GenerateMessage(Person receiver)
    {
        Topic previousTopic = Person.CurrentConversation.History.Last().Topic;
        Topic topic = RandomFromList<Topic>(Topic.SimilarTopics(previousTopic, 5, 0.1));
        MessageType type = RandomFromList<MessageType>(MessageType.GetAll<MessageType>());
        return new Message(Person, receiver, type, topic);
    }

    T RandomFromList<T>(IEnumerable<T> collection)
    {
        Random rand = new Random();
        int random = rand.Next(0, collection.Count());
        return collection.ElementAt<T>(random);
    }
}