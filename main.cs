using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using SociologySimulator.Models;
using Microsoft.EntityFrameworkCore;
using SociologySimulator.Utility;

class Program
{
    public static void Main(string[] args)
    {
        Topic.LoadFromFile("topics.json");

        // Person josh = PersonFactory.GenerateJosh(true);
        // Person matthew = PersonFactory.GenerateMatthew(false);

        // RequestableProperty joshTree = RequestableProperty.BuildRequestableTree(josh);
        // RequestableProperty.PrintAllQuestionsWithAnswers(joshTree);
        // answer a specific question: what is my current hunger?
        // Console.WriteLine("Current hunger: " + joshTree.GetChild("Psyche")?.GetChild("Needs")?.GetChild("Existence")?.GetChild("Food").GetChild("Fulfilled").Value);

        // Message greeting = josh.GenerateMessage(matthew);
        // josh.DeliverMessage(greeting);
        Console.WriteLine("Loading...");

        using var db = new SocialContext();

        // new stuff: how to query the db
        Person josh = new Person(db.Characters.Include(c => c.Mind).First());
        IPersonDriver player = new Player(josh);
        Node selected = josh.Character.Mind;
        while(db.Closures.Where(c => c.ParentId == selected.Id).Count() > 1){
            Console.WriteLine("You are examining " + selected.Name);
            // choose something to aggregate over
            List<List<string>> leafTagNames = db.Nodes.Where(n => db.Nodes.Select(n => n.ParentId).Contains(n.Id) == false && db.Closures.FirstOrDefault(c => c.ParentId == selected.Id && c.ChildId == n.Id) != null)
                .Select(n => n.Tags.Select(t => t.Name).ToList()).ToList();

            HashSet<string> namesInCommon = leafTagNames.Skip(1).Aggregate(new HashSet<string>(leafTagNames.First()),
                (set, tags) => set.Intersect(tags).ToHashSet()
            );

            // var temp = Input.ChooseFromList<Node>(leafDescendantsTags, "Which data to aggregate over?");
            var children = db.Nodes.Where(n => n.ParentId == selected.Id);
            int counter = 1;
            Console.WriteLine("Questions you could theoretically ask right now:");
            foreach (string name in namesInCommon)
            {
                Console.WriteLine(counter + ". What is the overall " + name + " of " + selected.Name + "? (todo)");
                counter++;
                Console.WriteLine(counter + ". Which type of " + selected.Name + " has the highest " + name + "? (todo)");
                counter++;
                foreach(var child in children)
                {
                    Console.WriteLine(counter + ". Which type of " + child.Name + " has the highest " + name + "? (todo)");
                    counter++;
                    Console.WriteLine(counter + ". What is the max value of " + child.Name + " in " + name + "? (todo)");
                    counter++;
                }
            }

            // choose which node to drill down into
            selected = Input.ChooseFromList<Node>(children, "Choose next node:");
        }
        Console.WriteLine("\nGame Finished");
    }
}