using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public struct Value : IDataList<Value>, ITyped
{
    public static HashSet<Value> All = new HashSet<Value>();

    public string Name { get; }
    public ValueCategory Category { get; }
    public object GetCategory => Category;

    public Value(string name, string category)
    {
        Name = name;
        Category = ValueCategory.All.First(vc => category == vc.Name);
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
            // List<string> tags = category.Split(',').Select(t => t.Trim()).ToList();
            All.Add(new Value(name, category));
        }
    }
}