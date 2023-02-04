using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models
{
    [PrimaryKey(nameof(ParentId), nameof(ChildId))]
    public class Closure
    {
        public Node Parent { get; set; }
        public int ParentId { get; set; }

        public Node Child { get; set; }
        public int ChildId { get; set; }

        [Required]
        public int Depth { get; set; }        
    }
}
