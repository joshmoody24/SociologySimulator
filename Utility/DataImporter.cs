using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class DataImporter
{
    public static T LoadFromJson<T>(string path)
    {
        string text = File.ReadAllText("./Resources/" + path);
        T data = JsonSerializer.Deserialize<T>(text);
        return data;
    }
}
