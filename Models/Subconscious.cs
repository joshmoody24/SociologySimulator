using SociologySimulator.Models.Motivations;
using SociologySimulator.Models.Sensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models
{
    // the part of the character that is actual data
    // and can generate a conscious
    // some parts of the conscious are 1:1 the same as the subconsious
    // but other things are different
    public class Subconscious
    {
        // MOTIVATIONS
        public SubconsciousCulturalValues CulturalValues;
        public SubconsciousPersonalValues PersonalValues;
        public SubconsciousPersonalityTraits PersonalityTraits;

        // KNOWLEDGE

        // RELATIONSHIPS
        public IEnumerable<Relationship> Relationships { get; set; }

        // ABILITIES
        // todo (maybe)

        // automatically make a tree structure based on the traits above
        public IEnumerable<Node> GenerateConsciousness(Appearance appearance, Senses senses)
        {
            List<Node> consciousness = new List<Node>();
            Node root = new Node("mind", null);
            consciousness.Add(root);

            // generate conscious values
            IEnumerable<Node> valueNodes = ConsciousnessBuilder.GeneratePersonalValues(CulturalValues, PersonalValues, root);
            consciousness.AddRange(valueNodes);

            IEnumerable<Node> traitNodes = ConsciousnessBuilder.GenerateTraits(PersonalityTraits, root);
            consciousness.AddRange(traitNodes);

            return consciousness;
        }
    }
}
