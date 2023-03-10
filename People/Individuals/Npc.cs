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
        (List<string>, QueryStepType) query = GenerateQuery(toQuery);
        return new Message(Person, receiver, query.Item1, type, query.Item2);
    }

    public (List<String>, QueryStepType) GenerateQuery(Person person)
    {
        List<string> query = new List<string>();
        var tree = RequestableProperty.BuildRequestableTree(person);
        while (tree.IsFloat == false)
        {
            tree = RandomFromList<RequestableProperty>(tree.Children);
            Console.WriteLine("NPC Adding " + tree.Info.Name);
            query.Add(tree.Info.Name);
        }
        return (query, QueryStepType.DrillDown);
    }

    T RandomFromList<T>(IEnumerable<T> collection)
    {
        Random rand = new Random();
        int random = rand.Next(0, collection.Count());
        return collection.ElementAt<T>(random);
    }
}