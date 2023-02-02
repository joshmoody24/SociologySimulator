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
        Topic topic = ChooseTopic();
        return new Message(Person, receiver, type, topic);
    }

    Topic ChooseTopic()
    {
        // temp debug stuff
        // generate list of queryable things
        // Psyche.GetRequestableProperties(Person.Psyche.GetType());
        Topic previousTopic = Person.CurrentConversation?.History.Last().Topic;
        IEnumerable<Topic> options = Topic.SimilarTopics(previousTopic, 5, 0.1);
        return ChooseFromList<Topic>(options, "Topics");
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