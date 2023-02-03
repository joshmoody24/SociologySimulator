using System.Collections.Generic;
using System.Linq;

public struct NeedCategory : IDataList<NeedCategory>
{
    public static IEnumerable<NeedCategory> All = new List<NeedCategory>();

    public string Name { get; }

    public NeedCategory(string name)
    {
        Name = name;
    }

    public static void LoadFromFile(string path)
    {
        All = DataImporter.LoadFromText(path).Select(name => new NeedCategory(name));
    }
}