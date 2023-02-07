using SociologySimulator.Models.Motivations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SociologySimulator.Models.Tags;

namespace SociologySimulator.Models
{
    public class ConsciousnessBuilder
    {
        public static IEnumerable<Node> GeneratePersonalValues(SubconsciousCulturalValues cultural, SubconsciousPersonalValues personal, Node parent)
        {
            List<Node> values = new List<Node>();
            Node pvRoot = new Node("personal values", parent);
            values.Add(pvRoot);
            values.Add(CreateValueNode("Law", pvRoot, (cultural.UncertaintyAvoidance + personal.Conservation)/2f));
            values.Add(CreateValueNode("Loyalty", pvRoot, (cultural.Collectivism + (1f-personal.SelfEnhancement))/2f));
            values.Add(CreateValueNode("Family", pvRoot, (cultural.Collectivism + (1f-personal.SelfDirection))/2f));
            values.Add(CreateValueNode("Friendship", pvRoot, ((1f - cultural.Masculinity) + personal.SelfTransendence)/2f));
            values.Add(CreateValueNode("Power", pvRoot, (cultural.PowerDistance + cultural.Masculinity + personal.Power)/3f));
            values.Add(CreateValueNode("Cunning", pvRoot, (cultural.ShortTermOrientation + (1f-personal.Universalism)) / 2f));
            values.Add(CreateValueNode("Fairness", pvRoot, (cultural.Collectivism + personal.SelfTransendence) / 2f));
            values.Add(CreateValueNode("Tradition", pvRoot, ((cultural.UncertaintyAvoidance) + personal.Conservation) / 2f));
            values.Add(CreateValueNode("Cooperation", pvRoot, (cultural.Collectivism + personal.Benevolence) / 2f));
            values.Add(CreateValueNode("Stoicism", pvRoot, (cultural.Masculinity + (1f - personal.Hedonism)) / 2f));
            values.Add(CreateValueNode("Introspection", pvRoot, ((1f - cultural.ShortTermOrientation) + (1f - personal.Stimulation))/2f));
            values.Add(CreateValueNode("Peace", pvRoot, (cultural.UncertaintyAvoidance + (1f-personal.Stimulation)) / 2f));
            values.Add(CreateValueNode("Partying", pvRoot, (cultural.ShortTermOrientation + personal.Hedonism) / 2f));
            values.Add(CreateValueNode("Skill", pvRoot, ((1f-cultural.Collectivism) + personal.Achievement) / 2f));
            values.Add(CreateValueNode("Hard Work", pvRoot, (cultural.Masculinity + personal.SelfDirection) / 2f));
            values.Add(CreateValueNode("Competition", pvRoot, (cultural.Masculinity + (1f-cultural.Collectivism) + personal.Power) / 3f));
            values.Add(CreateValueNode("Leisure Time", pvRoot, (cultural.ShortTermOrientation + (1f-personal.Stimulation)) / 2f));
            values.Add(CreateValueNode("Nature", pvRoot, ((1f-cultural.ShortTermOrientation) + personal.Universalism) / 2f));
            values.Add(CreateValueNode("Knowledge", pvRoot, ((1f - cultural.ShortTermOrientation) + personal.SelfDirection) / 2f));
            values.Add(CreateValueNode("Honesty", pvRoot, (cultural.Collectivism + personal.Spirituality + (1f-personal.SelfEnhancement)) /3f));
            values.Add(CreateValueNode("Humility", pvRoot, ((1f - cultural.PowerDistance) + personal.Spirituality + (1f - personal.SelfEnhancement)) / 3f));
            values.Add(CreateValueNode("Altruism", pvRoot, (cultural.Collectivism + personal.Spirituality + personal.SelfTransendence) / 3f));
            return values;
        }

        public static IEnumerable<Node> GenerateTraits(SubconsciousPersonalityTraits subTraits, Node parent)
        {
            List<Node> traits = new List<Node>();
            Node tRoot = new Node("personality traits", parent);
            traits.Add(tRoot);

            // 1:1 transfers
            traits.Add(CreateTraitNode("Open Minded", tRoot, subTraits.Openness));
            traits.Add(CreateTraitNode("Funny", tRoot, subTraits.Openness));
            traits.Add(CreateTraitNode("Curious", tRoot, subTraits.Openness));
            traits.Add(CreateTraitNode("Tolerant", tRoot, subTraits.Openness));

            traits.Add(CreateTraitNode("Confident", tRoot, subTraits.Conscientiousness));
            traits.Add(CreateTraitNode("Hard Working", tRoot, subTraits.Conscientiousness));
            traits.Add(CreateTraitNode("Focused", tRoot, subTraits.Conscientiousness));
            traits.Add(CreateTraitNode("Ambitious", tRoot, subTraits.Conscientiousness));

            traits.Add(CreateTraitNode("Outgoing", tRoot, subTraits.Extraversion));
            traits.Add(CreateTraitNode("Assertive", tRoot, subTraits.Extraversion));
            traits.Add(CreateTraitNode("Friendly", tRoot, subTraits.Extraversion));
            traits.Add(CreateTraitNode("Cheerful", tRoot, subTraits.Extraversion));

            traits.Add(CreateTraitNode("Stubborn", tRoot, 1f - subTraits.Agreeableness));
            traits.Add(CreateTraitNode("Altruistic", tRoot, subTraits.Agreeableness));
            traits.Add(CreateTraitNode("Modest", tRoot, subTraits.Agreeableness));
            traits.Add(CreateTraitNode("Chill", tRoot, subTraits.Agreeableness));

            traits.Add(CreateTraitNode("Nervous", tRoot, subTraits.Neuroticism));
            traits.Add(CreateTraitNode("Anxious", tRoot, subTraits.Neuroticism));
            traits.Add(CreateTraitNode("Stoic", tRoot, 1f-subTraits.Neuroticism));
            traits.Add(CreateTraitNode("Violent", tRoot, subTraits.Neuroticism));

            // combinations
            traits.Add(CreateTraitNode("Polite", tRoot, (subTraits.Agreeableness + subTraits.Extraversion)/2f));
            traits.Add(CreateTraitNode("Thoughtful", tRoot, ((1f-subTraits.Extraversion) + subTraits.Conscientiousness)/2f));
            return traits;
        }

        public static Node CreateValueNode(string name, Node parent, float importance)
        {
            Node node = new Node(name, parent);
            node.Tags.Add(new Tag(TagType.Number, "importance", importance.ToString()));
            return node;
        }

        public static Node CreateTraitNode(string name, Node parent, float intensity)
        {
            Node node = new Node(name, parent);
            node.Tags.Add(new Tag(TagType.Number, "intensity", intensity.ToString()));
            return node;
        }
    }
}
