using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SociologySimulator.Models
{
    public class Node
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Node Parent { get; set; }
        public int? ParentId { get; set; }

        public List<Tag> Tags { get; } = new();

        public override string ToString()
        {
            return Name;
        }
    }
}
