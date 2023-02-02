using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Player : IPersonDriver
{
    Person Person { get; }

    public Player(Person person)
    {
        Person = person;
    }

    public Message GenerateMessage(Person receiver)
    {
        MessageType type = ChooseMessageType();
        Person toQuery = type == MessageType.Request ? receiver : Person;
        List<string> query = ChooseQuery(toQuery);
        return new Message(Person, receiver, query, type);
    }

    /*
    Topic ChooseTopic()
    {
        Topic previousTopic = Person.CurrentConversation?.History.Last().Topic;
        IEnumerable<Topic> options = Topic.SimilarTopics(previousTopic, 5, 0.1);
        return ChooseFromList<Topic>(options, "Topics");
    }
    */

    List<string> ChooseQuery(Person person)
    {
        List<string> query = new List<string>();
        var tree = RequestableProperty.BuildRequestableTree(person);
        while(tree.IsFloat == false)
        {
            tree = ChooseChildProperty(tree);
            Console.WriteLine("Adding " + tree.Info.Name);
            query.Add(tree.Info.Name);
        }
        return query;
    }

    RequestableProperty ChooseChildProperty(RequestableProperty property)
    {
        return ChooseFromList<RequestableProperty>(property.Children, "Which property?");
    }

    MessageType ChooseMessageType()
    {
        return ChooseFromList(MessageType.GetAll<MessageType>(), "Message Types");
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