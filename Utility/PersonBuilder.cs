using SociologySimulator.Models;
using SociologySimulator.Models.Motivations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Utility
{
    public class PersonBuilder
    {
        public Person createJoshPlayer()
        {
            SubconsciousCulturalValues america = new SubconsciousCulturalValues()
            {
                Collectivism = 0.09f,
                PowerDistance = 0.4f,
                UncertaintyAvoidance = 0.46f,
                Masculinity = 0.62f,
                ShortTermOrientation = 0.74f
            };
            SubconsciousPersonalValues joshValues = new SubconsciousPersonalValues
            {
                Achievement = 0.9f,
                Benevolence = 0.9f,
                Conformity = 0.6f,
                Hedonism = 0.1f,
                Power = 0.1f,
                Security = 0.4f,
                SelfDirection = 0.6f,
                Spirituality = 0.85f,
                Stimulation = 0.2f,
                Tradition = 0.7f,
                Universalism = 0.8f
            };
            SubconsciousPersonalityTraits joshTraits = new SubconsciousPersonalityTraits
            { Openness = 0.875f, Conscientiousness = 0.6f, Extraversion = 0.25f, Agreeableness = 0.77f, Neuroticism = 0.48f };

            CharacterBuilder builder = new CharacterBuilder();
            Character joshCharacter = builder
                .SetHeight(183f)
                .SetWeight(145f)
                .SetEyeColor("brown")
                .SetHairColor("blonde")
                .SetFirstName("Josh")
                .SetLastName("Moody")
                .SetCulture(america)
                .SetValues(joshValues)
                .SetPersonality(joshTraits)
                .Build();
            Person josh = new Person(joshCharacter);
            IPersonDriver driver = new Player(josh);
            josh.Driver = driver;
            return josh;
        }
    }
}
