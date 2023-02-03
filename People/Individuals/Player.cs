using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<string> query = ChooseQuery(toQuery.Psyche);
        return new Message(Person, receiver, query, type, null);
    }

    public List<string> ChooseQuery(BasicPsyche psyche)
    {
        // find the most abstract non-homogenous ITypedObject type
        /*
        IEnumerable<PropertyInfo> queryableSetProperties = psyche.GetType().GetProperties()
            .Where(p => p.PropertyType.GetInterfaces().Contains(typeof(IEnumerable))
            && p.PropertyType.GetGenericArguments()[0].GetInterfaces().Contains(typeof(ITyped)));
        */
        //&& p.PropertyType.GetGenericArguments()[0].GetInterface("ITypedObject`1") != null);
        // same but renamable
        /*
        && p.PropertyType.GetGenericArguments()[0].GetInterfaces()
        .Where(i => i.IsGenericType)
        .Where(i => i.GetGenericTypeDefinition() == typeof(ITyped)).FirstOrDefault() != null);
        */

        // debug question examples

        // how important are existence needs to you?
        var q1 = psyche.Needs.Where(n => n.Need.Category.Name == NeedCategory.All.First(nc => nc.Name == "Existence").Name).Select(n => n.Importance).Average();

        // what value is most important to you?
        var q2 = psyche.Values.OrderByDescending(v => v.Importance).First().Value.Name;

        // how introverted are you?
        var q3 = 1f - psyche.Traits.Where(t => t.Trait.Category.Name == TraitCategory.All.First(tc => tc.Name == "Agreeableness").Name).Select(t => t.Status).Average();

       return null;
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