using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;

public class Topic
{

    public static List<Topic> AllTopics { get; private set; }

    public string Name { get; set; }
    public Topic DependsOn { get; set; }
    public List<float> Vector { get; set; }

    public Topic(string name, Topic dependsOn = null)
    {
        Name = name;
        DependsOn = dependsOn;
    }

    public static List<Topic> ReadCSV(string path)
    {
        string text = File.ReadAllText(path);
        List<Topic> topics = JsonSerializer.Deserialize<List<Topic>>(text);
        AllTopics = topics;
        return topics;
    }

    // randomness is between 0-2ish
    public static List<Topic> SimilarTopics(Topic topic, int limit = 5, double randomness = 0)
    {
        Random rnd = new Random();
        if (topic == null) return AllTopics.OrderBy(t => rnd.NextDouble()).Take(limit).ToList();
        List<Topic> possibleTopics = AllTopics.Where(t => t != topic).ToList();
        // very proud of this one liner
        return possibleTopics.OrderByDescending(t => t.ScaledSimilarity(topic.Vector) + (rnd.NextDouble() - 0.5) * randomness).Take(limit).ToList();
    }

    public double ScaledSimilarity(List<float> v2, double power = 1)
    {
        // 1.5 offset means low values get crushed and high values get rewarded
        return Math.Pow((CosineSimilarity(v2) + 1) / 2.0d, power);
    }

    public double CosineSimilarity(List<float> v2)
    {
        var v1 = Vector;
        int N = 0;
        N = ((v2.Count < v1.Count) ? v2.Count : v1.Count);
        double dot = 0.0d;
        double mag1 = 0.0d;
        double mag2 = 0.0d;
        for (int n = 0; n < N; n++)
        {
            dot += v1[n] * v2[n];
            mag1 += Math.Pow(v1[n], 2);
            mag2 += Math.Pow(v2[n], 2);
        }

        return dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2));
    }

    public override string ToString()
    {
        return Name;
    }




    /*
    // fundamental
    // public static readonly Topic HigherPower = new Topic("The Idea of a Higher Power");
    public static readonly Topic HeavenlyFather = new Topic("God is our loving Heavenly Father");
    public static readonly Topic GospelBlessesFamilies = new Topic("The gospel blesses individuals and families");
    // public static readonly Topic HeavenlyFather = new Topic("Heavenly Father", God);
    // public static readonly Topic JesusChrist = new Topic("Jesus Christ", HeavenlyFather);
    // public static readonly Topic HolyGhost = new Topic("Holy Ghost", HeavenlyFather);

    // restoration
    public static readonly Topic GospelDispensations = new Topic("gospel dispensations", HeavenlyFather);
    public static readonly Topic ChristEarthlyMinistry = new Topic("Jesus Christ's earthly ministry");
    public static readonly Topic GreatApostasy = new Topic("the great apostasy", ChristEarthlyMinistry);
    public static readonly Topic TheRestoration = new Topic("the Restoration", GreatApostasy);
    public static readonly Topic BookOfMormon = new Topic("The Book of Mormon", TheRestoration);
    public static readonly Topic PrayToKnowTruth = new Topic("praying to know the truth", BookOfMormon);

    // plan of salvation
    public static readonly Topic PremortalLife = new Topic("premortal life", HeavenlyFather);
    public static readonly Topic Creation = new Topic("the creation");
    public static readonly Topic FallOfAdamAndEve = new Topic("the fall of Adam and Eve", HeavenlyFather);
    public static readonly Topic OurLifeOnEarth = new Topic("our life on Earth", FallOfAdamAndEve);
    public static readonly Topic Atonement = new Topic("the Atonement of Jesus Christ", FallOfAdamAndEve);
    // public static readonly Topic LifeAfterDeath = new Topic("life after death", HigherPower);
    public static readonly Topic SpiritWorld = new Topic("the spirit world", PremortalLife);
    public static readonly Topic KingdomsOfGlory = new Topic("kingdoms of glory", SpiritWorld);

    // gospel of christ
    public static readonly Topic FaithInJesusChrist = new Topic("faith in Jesus Christ");
    public static readonly Topic Repentance = new Topic("repentance", Atonement);
    public static readonly Topic Baptism = new Topic("baptism", Repentance);
    public static readonly Topic GiftOfTheHolyGhost = new Topic("the gift of the Holy Ghost", Baptism);
    public static readonly Topic EnduringToTheEnd = new Topic("enduring to the end", GiftOfTheHolyGhost);

    // commandments
    // public static readonly Topic ScriptureStudy = new Topic("Scripture Study", Revelation);
    // public static readonly Topic Pray = new Topic("Pray", Revelation);
    public static readonly Topic SabbathDay = new Topic("keeping the sabbath day holy", HeavenlyFather);
    public static readonly Topic LawOfChastity = new Topic("the law of chastity", OurLifeOnEarth);
    public static readonly Topic WordOfWisdom = new Topic("the word of wisdom", TheRestoration);
    public static readonly Topic Tithing = new Topic("tithing");

    // laws and ordinances
    public static readonly Topic Temples = new Topic("temples", SpiritWorld);
	*/
}