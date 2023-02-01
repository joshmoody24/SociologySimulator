using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        var topics = Topic.ReadCSV("topics.json");
        // Console.WriteLine(topics[0].ToString());

        var broadtopics = BroadTopic.ReadCSV("topics_broad.json");
        // Console.WriteLine(broadtopics[0].ToString());

        Person josh = PersonFactory.GenerateJosh(true);
        Person matthew = PersonFactory.GenerateMatthew(false);
        Topic topic = Topic.AllTopics[0];
        Message greeting = josh.GenerateMessage(matthew);
        josh.DeliverMessage(greeting);
    }
}