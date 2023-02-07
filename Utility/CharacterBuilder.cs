using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using SociologySimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using SociologySimulator.Models.Sensing;
using SociologySimulator.Models.Motivations;

namespace SociologySimulator.Utility
{
    public class CharacterBuilder
    {
        private Character character;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => FirstName + " " + LastName;

        public Appearance Appearance { get; set; }
        public Senses Senses { get; set; }
        public Subconscious Subconscious { get; set; }
        public IEnumerable<Node> Mind => Subconscious.GenerateConsciousness(Appearance, Senses);
        public CharacterBuilder()
        {
            character = new Character();
            character.Appearance = new Appearance();
            character.Subconscious = new Subconscious();
        }

        public CharacterBuilder SetFirstName(string firstName)
        {
            character.FirstName = firstName;
            return this;
        }
        public CharacterBuilder SetLastName(string lastName)
        {
            character.LastName = lastName;
            return this;
        }
        public CharacterBuilder SetEyeColor(string color)
        {
            character.Appearance.EyeColor = color;
            return this;
        }
        public CharacterBuilder SetHairColor(string color)
        {
            character.Appearance.HairColor = color;
            return this;
        }
        public CharacterBuilder SetHeight(float height)
        {
            character.Appearance.Height = height;
            return this;
        }
        public CharacterBuilder SetWeight(float weight)
        {
            character.Appearance.Weight = weight;
            return this;
        }
        public CharacterBuilder SetCulture(SubconsciousCulturalValues culture)
        {
            character.Subconscious.CulturalValues = culture;
            return this;
        }
        public CharacterBuilder SetValues(SubconsciousPersonalValues values)
        {
            character.Subconscious.PersonalValues = values;
            return this;
        }
        public CharacterBuilder SetPersonality(SubconsciousPersonalityTraits traits)
        {
            character.Subconscious.PersonalityTraits = traits;
            return this;
        }
        public Character Build()
        {
            return character;
        }
    }
}
