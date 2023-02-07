using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using SociologySimulator.Models;
using Microsoft.EntityFrameworkCore;
using SociologySimulator.Utility;
using System.Xml.Linq;
using SociologySimulator.Models.Tags;

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

        Person josh = new PersonBuilder().createJoshPlayer();
        // get root node
        Node selected = josh.Character.Mind.First(n => n.Path.Length == josh.Character.Mind.Min(m => m.Path.Length));

        while(josh.Character.GetDescendants(selected).Count() > 0){
            Console.WriteLine("You are examining " + josh.Character.FirstName + "'s " + selected.Name);

            // choose something to aggregate over
            List<List<Tag>> leafTags = josh.Character.GetLeaves(selected)
                .Select(n => n.Tags.ToList())
                .ToList();

            HashSet<Tag> tagsInCommon = leafTags.Skip(1).Aggregate(new HashSet<Tag>(leafTags.First()),
                (set, tags) => set.Intersect(tags).ToHashSet()
            );

            // var temp = Input.ChooseFromList<Node>(leafDescendantsTags, "Which data to aggregate over?");
            int counter = 1;
            Console.WriteLine("Questions you could theoretically ask right now:");
            foreach (Tag tag in tagsInCommon)
            {
                if(tag.Type == TagType.Number)
                {
                    Console.WriteLine(counter + ". What is the overall " + tag.Name + " of " + selected.Name + "? (todo)");
                    counter++;
                    Console.WriteLine(counter + ". Which type of " + selected.Name + " has the highest " + tag.Name + "? (todo)");
                    counter++;
                }
                else if(tag.Type == TagType.String)
                {
                    Console.WriteLine(counter + ". What is your " + tag.Name + "?");
                }
            }

            // choose which node to drill down into
            selected = Input.ChooseFromList<Node>(josh.Character.GetChildren(selected), "Choose next node:");
        }
        Console.WriteLine("Your selected node is: " + selected.NameWithTags());
        Console.WriteLine("\nGame Finished");
    }
}