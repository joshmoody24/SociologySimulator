using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models.Motivations
{
    public struct SubconsciousPersonalValues
    {
        public float SelfDirection { get; set; } // Independent thought and action—choosing, creating, exploring.
        public float Stimulation { get; set; } // Excitement, novelty and challenge in life.
        public float Hedonism { get; set; } // Pleasure or sensuous gratification for oneself.
        public float Achievement { get; set; } //Personal success through demonstrating competence according to social standards.
        public float Power { get; set; } // Social status and prestige, control or dominance over people and resources.
        public float Security { get; set; } // Safety, harmony, and stability of society, of relationships, and of self.
        public float Conformity { get; set; } // Restraint of actions, inclinations, and impulses likely to upset or harm others and violate social expectations or norms.
        public float Tradition { get; set; } // Respect, commitment, and acceptance of the customs and ideas that one's culture or religion provides.       
        public float Benevolence { get; set; } // Preserving and enhancing the welfare of those with whom one is in frequent personal contact(the ‘in-group’).
        public float Universalism { get; set; } // Understanding, appreciation, tolerance, and protection for the welfare of all people and for nature.
        public float Spirituality { get; set; }

        public float OpennessToChange => (SelfDirection + Stimulation) / 2f;
        public float SelfEnhancement => (Hedonism + Achievement + Power) / 3f;
        public float Conservation => (Security + Conformity + Tradition) / 3f;
        public float SelfTransendence => (Benevolence + Universalism) / 2f;
    }
}
