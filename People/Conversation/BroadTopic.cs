using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class BroadTopic
{

    public static List<BroadTopic> All { get; private set; }

    public string Name { get; set; }
    public List<float> Vector { get; set; }

    public BroadTopic(string name)
    {
        Name = name;
    }

    public static List<BroadTopic> ReadCSV(string path)
    {
        string text = File.ReadAllText(path);
        List<BroadTopic> topics = JsonSerializer.Deserialize<List<BroadTopic>>(text);
        All = topics;
        return topics;
    }

		public override string ToString(){
			return Name + ": [" + string.Join(", " , Vector) + "]";
		}
}