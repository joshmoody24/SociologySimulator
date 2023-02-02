using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class RequestableProperty
{
    public PropertyInfo Info { get; set; }
    public Object Value { get; set; }
    public List<RequestableProperty> Children { get; set; }
    public bool IsFloat => (Children == null || Children.Count == 0);
    public float Reduction => IsFloat ? (float)Value : Children.Select(rn => rn.Reduction).Average();

    public RequestableProperty(PropertyInfo info, Object value, List<RequestableProperty> children)
    {
        Info = info;
        Value = value;
        Children = children;
    }

    public static RequestableProperty BuildRequestableTree(Object instance, PropertyInfo info = null, int depth = 0)
    {
        List<RequestableProperty> children = new List<RequestableProperty>();
        Type t = instance.GetType();
        IEnumerable<PropertyInfo> requestableProperties = t.GetProperties()
            .Where(p => p.PropertyType == typeof(float) || Attribute.GetCustomAttribute(p.PropertyType, typeof(Requestable)) != null);
        foreach (PropertyInfo prop in requestableProperties)
        {
            Object obj = prop.GetValue(instance);
            children.Add(BuildRequestableTree(obj, prop, depth + 1));
        }
        return new RequestableProperty(info, instance, children);
    }

    public override string ToString()
    {
        return Info.Name;
    }

    // debug
    public static void PrintAllQuestionsWithAnswers(RequestableProperty node, int depth = 0)
    {
        string indent = new string(' ', depth * 2);
        Console.WriteLine(indent + (node.Info?.Name ?? "Root") + ": " + node.Reduction);
        foreach (RequestableProperty p in node.Children) PrintAllQuestionsWithAnswers(p, depth + 1);
    }

    public RequestableProperty GetChild(string name)
    {
        return Children.FirstOrDefault(c => c.Info.Name == name);
    }
}