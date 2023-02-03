using System.Collections.Generic;
using System.Linq;
using System.IO;

public struct Need : IDataList<Need>, ITyped
{
    public static HashSet<Need> All = new HashSet<Need>();

    public string Name { get; }
    public NeedCategory Category { get; }
    public object GetCategory => Category;

    public Need(string name, string category)
    {
        Name = name;
        Category = NeedCategory.All.First(nc => category == nc.Name);
    }

    public static void LoadFromFile(string path)
    {
        foreach(string s in DataImporter.LoadFromText(path))
        {
            if (s.Trim() == "") continue;
            string[] split = s.Split('|');
            if (split.Length != 2) throw new FileFormatException();
            string name = split[0].Trim();
            string category = split[1].Trim();
            //List<string> tags = tagBlock.Split(',').Select(t => t.Trim()).ToList();
            All.Add(new Need(name, category));
        }
    }

}