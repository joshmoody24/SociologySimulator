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
    public List<RequestableProperty> RankedChildren => Children.OrderBy(rn => rn.Reduction).ToList();

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
            object obj = prop.GetValue(instance);
            children.Add(BuildRequestableTree(obj, prop, depth + 1));
        }
        return new RequestableProperty(info, instance, children);
    }

    public List<string> GetPossibleQuestions()
    {
        var commonProperties = GetCommonProperties();
        bool isRankable = GetCommonProperties().Count() > 0 && Attribute.GetCustomAttribute(Info.PropertyType, typeof(Rankable)) != null;
        foreach(var property in commonProperties)
        {
            // select
            Console.WriteLine("What is the value of " + property);

            // rank
            if (isRankable)
            {
                Console.WriteLine("Which of your " + Info.Name + "  has the most " + property);
                Console.WriteLine("Which of your " + Info.Name + " has the least " + property);
            }
         }
        return null;
    }

    // get the properties all of its leaf nodes have in common
    public IEnumerable<string> GetCommonProperties()
    {
        var leafChildren = Children.Where(c => c.Children.Count == 0);
        var branchChildren = Children.Where(c => c.Children.Count > 0);
        var set = new HashSet<string>();
        if (leafChildren.Count() > 0 && branchChildren.Count() > 0) return new HashSet<string>();
        if (branchChildren.Count() == 0) return leafChildren.Select(c => c.Info.Name).Distinct();

        IEnumerable<IEnumerable<string>> childSets = branchChildren.Select(c => c.GetCommonProperties());
        var intersection = childSets
            .Skip(1)
            .Aggregate(
                new HashSet<string>(childSets.First()),
                (h, e) => { h.IntersectWith(e); return h; }
            );
        return intersection;
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