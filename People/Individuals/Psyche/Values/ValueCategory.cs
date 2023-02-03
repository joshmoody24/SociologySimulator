using System;
using System.Collections.Generic;
using System.Linq;

public struct ValueCategory : IDataList<ValueCategory>
{
    public static IEnumerable<ValueCategory> All = new List<ValueCategory>();

    public string Name { get; }

    public ValueCategory(string name)
    {
        Name = name;
    }

    public static void LoadFromFile(string path)
    {
        All = DataImporter.LoadFromText(path).Select(name => new ValueCategory(name));
    }
}