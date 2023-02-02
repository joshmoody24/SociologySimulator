// debug class, will improve later

using System.Linq;

public class PersonFactory
{

    public static Culture AmericanCulture = new Culture
    {
        Name = "USA",
        Values = new Values
        {
            Collectivism = 0.09f,
            PowerDistance = 0.4f,
            UncertaintyAvoidance = 0.46f,
            Masculinity = 0.62f,
            ShortTermOrientation = 0.74f,
        }
    };

    public static Person GenerateJosh(bool playerControlled)
    {

        Traits joshTraits = new Traits(
                openness: 0.875f,
                conscientiousness: 0.6f,
                extraversion: 0.25f,
                agreeableness: 0.77f,
                neuroticism: 0.48f
        );

        ExistenceNeeds joshExistence = new ExistenceNeeds
        {
            Food = new Need { Importance = 1f, Fulfilled = 0.9f },
            Water = new Need { Importance = 1f, Fulfilled = 0.8f },
            Sleep = new Need { Importance = 0.8f, Fulfilled = 0.4f },
            Reproduction = new Need { Importance = 0.1f, Fulfilled = 0f },
            Shelter = new Need { Importance = 0.9f, Fulfilled = 1f },
            Security = new Need { Importance = 0.5f, Fulfilled = 0.8f },
        };

        RelatednessNeeds joshRelatedness = new RelatednessNeeds
        {
            Friendship = new Need { Importance = 0.2f, Fulfilled = 0.5f },
            Love = new Need { Importance = 0.5f, Fulfilled = 0.9f },
            Intimacy = new Need { Importance = 0.4f, Fulfilled = 0.5f },
            Family = new Need { Importance = 0.7f, Fulfilled = 0.9f },
        };

        GrowthNeeds joshGrowth = new GrowthNeeds
        {
            Respect = new Need { Importance = 0.2f, Fulfilled = 0.8f },
            SelfEsteem = new Need { Importance = 0.5f, Fulfilled = 0.7f },
            Status = new Need { Importance = 0.2f, Fulfilled = 0.2f },
            Recognition = new Need { Importance = 0.1f, Fulfilled = 0.8f },
            Freedom = new Need { Importance = 0.5f, Fulfilled = 0.8f },
            Achievement = new Need { Importance = 0.95f, Fulfilled = 0.6f },
            Autonomy = new Need { Importance = 0.5f, Fulfilled = 0.6f },
        };

        Needs joshNeeds = new Needs(joshExistence, joshRelatedness, joshGrowth);

        Knowledge emptyKnowledge = new Knowledge();

        BasicPsyche joshPsyche = new BasicPsyche(AmericanCulture, joshTraits, emptyKnowledge, joshNeeds);

        Person josh = new Person("Josh", "Moody", joshPsyche);
        IPersonDriver driver = playerControlled ? new Player(josh) : new Npc(josh);
        josh.Driver = driver;
        return josh;
    }

    public static Person GenerateMatthew(bool playerControlled)
    {

        Traits matthewTraits = new Traits(
                openness: 0.875f,
                conscientiousness: 0.8f,
                extraversion: 0.5f,
                agreeableness: 0.1f,
                neuroticism: 0.48f
        );

        ExistenceNeeds matthewExistence = new ExistenceNeeds
        {
            Food = new Need { Importance = 1f, Fulfilled = 0.9f },
            Water = new Need { Importance = 1f, Fulfilled = 0.8f },
            Sleep = new Need { Importance = 0.8f, Fulfilled = 0.4f },
            Reproduction = new Need { Importance = 0.1f, Fulfilled = 0f },
            Shelter = new Need { Importance = 0.9f, Fulfilled = 1f },
            Security = new Need { Importance = 0.5f, Fulfilled = 0.8f },
        };

        RelatednessNeeds matthewRelatedness = new RelatednessNeeds
        {
            Friendship = new Need { Importance = 0.2f, Fulfilled = 0.5f },
            Love = new Need { Importance = 0.5f, Fulfilled = 0.9f },
            Intimacy = new Need { Importance = 0.4f, Fulfilled = 0.5f },
            Family = new Need { Importance = 0.7f, Fulfilled = 0.9f },
        };

        GrowthNeeds matthewGrowth = new GrowthNeeds
        {
            Respect = new Need { Importance = 0.2f, Fulfilled = 0.8f },
            SelfEsteem = new Need { Importance = 0.5f, Fulfilled = 0.7f },
            Status = new Need { Importance = 0.2f, Fulfilled = 0.2f },
            Recognition = new Need { Importance = 0.1f, Fulfilled = 0.8f },
            Freedom = new Need { Importance = 0.5f, Fulfilled = 0.8f },
            Achievement = new Need { Importance = 0.95f, Fulfilled = 0.6f },
            Autonomy = new Need { Importance = 0.5f, Fulfilled = 0.6f },
        };

        Needs matthewNeeds = new Needs(matthewExistence, matthewRelatedness, matthewGrowth);

        Knowledge emptyKnowledge = new Knowledge();

        BasicPsyche matthewPsyche = new BasicPsyche(AmericanCulture, matthewTraits, emptyKnowledge, matthewNeeds);


        Person matthew = new Person("Matthew", "Moody", matthewPsyche);

        IPersonDriver driver = playerControlled ? new Player(matthew) : new Npc(matthew);
        matthew.Driver = driver;
        return matthew;
    }
}