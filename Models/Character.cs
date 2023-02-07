using SociologySimulator.Models.Sensing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SociologySimulator.Models
{
    public struct Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => FirstName + " " + LastName;

        public Appearance Appearance { get; set; }
        public Senses Senses { get; set; }
        public Subconscious Subconscious { get;set; }
        public IEnumerable<Node> Mind => Subconscious.GenerateConsciousness(Appearance, Senses);

        public IEnumerable<Node> GetDescendants(Node selected)
        {
            return Mind.Where(n => n.Path != selected.Path && n.Path.Contains(selected.Path));
        }

        public IEnumerable<Node> GetChildren(Node selected)
        {
            int depth = selected.Path.Split("/").Length;
            return GetDescendants(selected).Where(n => n.Path.Split("/", StringSplitOptions.None).Length == depth + 1);
        }

        public IEnumerable<Node> GetLeaves(Node selected)
        {
            var descendants = GetDescendants(selected);
            return descendants.Where(n => descendants.Where(d => d.Path.Contains(n.Path)).Count() == 1);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
