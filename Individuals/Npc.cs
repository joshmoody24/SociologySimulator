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
        MessageType type = RandomFromList<MessageType>(MessageType.GetAll<MessageType>());
        Person toQuery = type == MessageType.Request ? receiver : Person;
        return new Message(Person, receiver, null, type);
    }

    T RandomFromList<T>(IEnumerable<T> collection)
    {
        Random rand = new Random();
        int random = rand.Next(0, collection.Count());
        return collection.ElementAt<T>(random);
    }
}