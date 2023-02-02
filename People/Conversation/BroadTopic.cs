using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class BroadTopic
{

    public static List<BroadTopic> AllBroadTopics { get; private set; }

    public string Name { get; set; }
    public List<float> Vector { get; set; }

    public BroadTopic(string name)
    {
        Name = name;
    }

    public static void LoadFromFile(string path)
    {
        AllBroadTopics = DataImporter.LoadFromJson<List<BroadTopic>>(path);
    }

    public override string ToString(){
	    return Name + ": [" + string.Join(", " , Vector) + "]";
    }
}