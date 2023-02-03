using System.Collections.Generic;
using System.Linq;

public struct TraitCategory : IDataList<TraitCategory>
{
    public static IEnumerable<TraitCategory> All = new List<TraitCategory>();

    public string Name { get; }

    public TraitCategory(string name)
    {
        Name = name;
    }

    public static void LoadFromFile(string path)
    {
        All = DataImporter.LoadFromText(path).Select(name => new TraitCategory(name));
    }
}