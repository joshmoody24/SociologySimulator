using System;

class Program
{
    public static void Main(string[] args)
    {
        Values americanValues = new Values
        {
            Collectivism = 0.09f,
            PowerDistance = 0.4f,
            UncertaintyAvoidance = 0.46f,
            Masculinity = 0.62f,
            ShortTermOrientation = 0.74f,
        };

        Culture americanCulture = new Culture
        {
            Name = "USA",
            Values = americanValues,
        };

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

        Person josh = new Person("Josh", "Moody", americanCulture, joshTraits);
        Console.WriteLine(josh.FirstName);
    }
}