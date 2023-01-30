using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

// name is also id
public abstract class Enumeration : IComparable
{
    public string Name { get; private set; }


    protected Enumeration(string name) => (Name) = (name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Name.Equals(otherValue.Name);

        return typeMatches && valueMatches;
    }

    // TODO: make a better one if problems are encountered
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public int CompareTo(object other) => Name.CompareTo(((Enumeration)other).Name);

    // Other utility methods ...
}