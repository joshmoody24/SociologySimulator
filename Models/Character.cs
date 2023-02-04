using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models
{
    public class Character
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Name => FirstName + " " + LastName;

        public Node Mind { get; set; }
        public int MindId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
