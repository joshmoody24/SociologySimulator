using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

class RequestableNode
{
    public PropertyInfo Info { get; set; }
    public Object Value { get; set; }
    public List<RequestableNode> Children { get; set; }
    public RequestableNode(PropertyInfo info, Object value, List<RequestableNode> children)
    {
        Info = info;
        Value = value;
        Children = children;
    }
    public float Reduction => (Children == null || Children.Count == 0)  ? (float)Value : Children.Select(rn => rn.Reduction).Average();
    public RequestableNode GetChild(string name)
    {
        return Children.FirstOrDefault(c => c.Info.Name == name);
    }
}

class Program
{
    public static RequestableNode BuildRequestableTree(Object instance, PropertyInfo info = null, int depth = 0)
    {
        const int MAX_DEPTH = 10;
        if (depth > MAX_DEPTH) return null;

        List<RequestableNode> children = new List<RequestableNode>();

        Type t = instance.GetType();

        IEnumerable<PropertyInfo> requestableProperties = t.GetProperties()
            .Where(p => p.PropertyType == typeof(float) || Attribute.GetCustomAttribute(p.PropertyType, typeof(Requestable)) != null);

        foreach(PropertyInfo prop in requestableProperties)
        {
            Object obj = prop.GetValue(instance);
            children.Add(BuildRequestableTree(obj, prop, depth + 1));
        }
        return new RequestableNode(info, instance, children);
    }

    public static void PrintAllQuestionsWithAnswers(RequestableNode node, int depth = 0)
    {
        string indent = new string(' ', depth * 2);
        Console.WriteLine(indent + (node.Info?.Name ?? "Root") + ": " + node.Reduction);
        foreach(RequestableNode n in node.Children) PrintAllQuestionsWithAnswers(n, depth + 1);
    }

    public static void Main(string[] args)
    {
        Topic.LoadFromFile("topics.json");
        Topic.LoadFromFile("topics_broad.json");

        Person josh = PersonFactory.GenerateJosh(true);
        Person matthew = PersonFactory.GenerateMatthew(false);

        var tree = BuildRequestableTree(josh);
        PrintAllQuestionsWithAnswers(tree);
        // answer a specific question: what is my current hunger?
        Console.WriteLine("Current hunger: " + tree.GetChild("Psyche")?.GetChild("Needs")?.GetChild("Existence")?.GetChild("Food").GetChild("Fulfilled").Value);

        Topic topic = Topic.AllTopics[0];
        Message greeting = josh.GenerateMessage(matthew);
        josh.DeliverMessage(greeting);
    }
}