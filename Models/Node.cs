using System;
using System.Collections.Generic;
using System.Linq;
using SociologySimulator.Models.Tags;

namespace SociologySimulator.Models
{
    public class Node
    {

        public string Path { get; set; }

        public string Name => Path.Split("/").Reverse().Skip(1).Take(1).FirstOrDefault() ?? "<missing>";

        public List<Tag> Tags { get; set; } = new();

        public Node(string name, Node parent)
        {
            Path = (parent?.Path ?? "/") + name + "/";
            Tags = new List<Tag>();
        }

        public Node(String path)
        {
            Path = path;
        }

        public override string ToString()
        {
            return Name;
        }

        public string NameWithTags()
        {
            string str = Name;
            foreach (Tag tag in Tags)
            {
                str += " (" + tag.ToString() + ")";
            }
            return str;
        }
    }
}
