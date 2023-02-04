using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models
{
    [PrimaryKey(nameof(NodeId), nameof(Name))]
    public class Tag
    {
        [Required]
        public string Name { get; set; }

        public Node Node { get; set; }
        public int NodeId { get; set; }

        public Type Type { get; set; }
        public int TypeId { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Name + $"({Value})";
        }

    }
}
