using System.Linq;

public class Topic : Enumeration
{
    public Topic DependsOn { get; set; }

    public Topic(string name, Topic dependsOn = null) : base(name)
    {
        DependsOn = dependsOn;
    }
    // fundamental
    public static readonly Topic HigherPower = new Topic("The Idea of a Higher Power");
    public static readonly Topic God = new Topic("God", HigherPower);
    public static readonly Topic HeavenlyFather = new Topic("Heavenly Father", God);
    public static readonly Topic JesusChrist = new Topic("Jesus Christ", HeavenlyFather);
    public static readonly Topic HolyGhost = new Topic("Holy Ghost", HeavenlyFather);

    // restoration
    public static readonly Topic Revelation = new Topic("Revelation", HeavenlyFather);
    public static readonly Topic ChurchOfJesusChrist = new Topic("The Church of Jesus Christ", JesusChrist);
    public static readonly Topic GreatApostasy = new Topic("Great Apostasy", ChurchOfJesusChrist);
    public static readonly Topic JosephSmith = new Topic("Joseph Smith", GreatApostasy);
    public static readonly Topic BookOfMormon = new Topic("The Book of Mormon", JosephSmith);

    // plan of salvation
    public static readonly Topic PremortalLife = new Topic("Premortal Life", HeavenlyFather);
    public static readonly Topic Creation = new Topic("The Creation", HigherPower);
    public static readonly Topic FallOfAdamAndEve = new Topic("The Fall of Adam and Eve", HeavenlyFather);
    public static readonly Topic PurposeOfLife = new Topic("Our Life On Earth", FallOfAdamAndEve);
    public static readonly Topic Atonement = new Topic("The Atonement of Jesus Christ", FallOfAdamAndEve);
    public static readonly Topic LifeAfterDeath = new Topic("Life After Death", HigherPower);
    public static readonly Topic SpiritWorld = new Topic("The Spirit World", PremortalLife);
    public static readonly Topic KingdomsOfGlory = new Topic("Kingdoms of Glory", SpiritWorld);

    // gospel of christ
    public static readonly Topic FaithInJesusChrist = new Topic("Faith in Jesus Christ", JesusChrist);
    public static readonly Topic Repentance = new Topic("Repentance", Atonement);
    public static readonly Topic Baptism = new Topic("Baptism", Repentance);
    public static readonly Topic GiftOfTheHolyGhost = new Topic("The Gift of the Holy Ghost", Baptism);
    public static readonly Topic EndureToTheEnd = new Topic("Endure to the End", GiftOfTheHolyGhost);

    // commandments
    public static readonly Topic ScriptureStudy = new Topic("Scripture Study", Revelation);
    public static readonly Topic Pray = new Topic("Pray", Revelation);
    public static readonly Topic SabbathDay = new Topic("Keep the Sabbath Day Holy", HeavenlyFather);
    public static readonly Topic LawOfChastity = new Topic("The Law of Chastity", PurposeOfLife);
    public static readonly Topic WordOfWisdom = new Topic("The Word of Wisdom", JosephSmith);
    public static readonly Topic Tithing = new Topic("Tithing", ChurchOfJesusChrist);

    // laws and ordinances
    public static readonly Topic Temples = new Topic("Temples and Family History", SpiritWorld);
}