using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

class Program
{
    public static void Main(string[] args)
    {
        Topic.LoadFromFile("topics.json");
        BroadTopic.LoadFromFile("topics_broad.json");
        NeedCategory.LoadFromFile("NeedCategories.txt");
        TraitCategory.LoadFromFile("TraitCategories.txt");
        ValueCategory.LoadFromFile("ValueCategories.txt");
        Trait.LoadFromFile("Traits.txt");
        Need.LoadFromFile("Needs.txt");
        Value.LoadFromFile("Values.txt");

        Person josh = PersonFactory.GenerateJosh(true);
        Person matthew = PersonFactory.GenerateMatthew(false);

        // RequestableProperty joshTree = RequestableProperty.BuildRequestableTree(josh);
        // RequestableProperty.PrintAllQuestionsWithAnswers(joshTree);
        // answer a specific question: what is my current hunger?
        // Console.WriteLine("Current hunger: " + joshTree.GetChild("Psyche")?.GetChild("Needs")?.GetChild("Existence")?.GetChild("Food").GetChild("Fulfilled").Value);

        Message greeting = josh.GenerateMessage(matthew);
        josh.DeliverMessage(greeting);
    }
}