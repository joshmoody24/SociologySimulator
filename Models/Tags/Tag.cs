using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SociologySimulator.Models.Tags
{
    public struct Tag
    {
        public string Name { get; set; }
        public TagType Type { get; set; }
        public string Value { get; set; }

        public Tag(TagType type, string name,  string value)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public override string ToString()
        {
            return Name + $": {Value}";
        }

        public override int GetHashCode()
        {
            return Name.Length * (int)Type;
        }

        // compares on name only
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Tag)) return false;
            Tag other = (Tag)obj;
            return Name == other.Name && other.Type == Type;
        }
    }
}
