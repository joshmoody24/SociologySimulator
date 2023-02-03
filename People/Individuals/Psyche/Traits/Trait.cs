using System.Collections.Generic;
using System.Linq;
using System.IO;

public struct Trait : IDataList<Trait>, ITyped
{
    public static HashSet<Trait> All = new HashSet<Trait>();

    public TraitCategory Category { get; }
    public object GetCategory => Category;

    public string Name { get; }

    public Trait(string name, string category)
    {
        Name = name;
        Category = TraitCategory.All.First(tc => tc.Name == category);
    }

    public static void LoadFromFile(string path)
    {
        foreach (string s in DataImporter.LoadFromText(path))
        {
            if (s.Trim() == "") continue;
            string[] split = s.Split('|');
            if (split.Length != 2) throw new FileFormatException();
            string name = split[0].Trim();
            string category = split[1].Trim();
            //List<string> tags = tagBlock.Split(',').Select(t => t.Trim()).ToList();
            All.Add(new Trait(name, category));
        }
    }
}