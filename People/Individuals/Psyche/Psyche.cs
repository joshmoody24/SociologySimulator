using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

[Requestable]
public abstract class Psyche
{
    const int MAX_DEPTH = 20;

    public static void GetRequestableProperties(Type t, int depth = MAX_DEPTH)
    {
        IEnumerable<PropertyInfo> properties = t.GetProperties();        
        foreach(PropertyInfo property in properties)
        {
            PrintAllQuestionsFromProperty(t, property, depth);
        }
    }

    public static void PrintAllQuestionsFromProperty(Type parentType, PropertyInfo property, int depth = MAX_DEPTH)
    {
        Requestable requestable = (Requestable)Attribute.GetCustomAttribute(property.PropertyType, typeof(Requestable));
        Requestable parentRequestable = (Requestable)Attribute.GetCustomAttribute(parentType, typeof(Requestable));
        requestable = requestable ?? parentRequestable;

        NotRequestable notRequestable = (NotRequestable)Attribute.GetCustomAttribute(property, typeof(NotRequestable));

        Rankable rankable = (Rankable)Attribute.GetCustomAttribute(property.PropertyType, typeof(Rankable));
        Reducible reducible = (Reducible)Attribute.GetCustomAttribute(property.PropertyType, typeof(Reducible));
        
        if (requestable == null || notRequestable != null)
        {
            return;
        }

        if (depth <= 0)
        {
            Console.WriteLine("Maximum request depth exceeded");
            return;
        };
        
        // questions for lists of things
        if(rankable != null)
        {
            Console.WriteLine("Please rank " + Prettify(property.Name));
        }

        // questions for things with a numerical value
        if(property.PropertyType == typeof(float) || reducible != null)
        {
            Console.WriteLine(requestable.question + " " + property.Name + "?");
        }

        // questions for things with a text value
        if(property.PropertyType == typeof(string))
        {
            Console.WriteLine("What is the " + Prettify(property.Name) + " of your " + Prettify(parentType.Name) + "?");
        }

        // when to recurse
        if(rankable != null || requestable != null){
            GetRequestableProperties(property.PropertyType, depth - 1);
        }
    }

    public static string Prettify(string camelCase)
    {
        return Regex.Replace(camelCase, "(\\B[A-Z])", " $1");
    }
}
