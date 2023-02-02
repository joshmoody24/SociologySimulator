public class MessageType : Enumeration
{

    public string Verb { get; private set; }
    public string Description { get; private set; }

    public MessageType(string name, string verb, string description) : base(name)
    {
        Verb = verb;
        Description = description;
    }

    public static MessageType Request = new MessageType("Ask Something", "asked", "by asking about");
    public static MessageType Share = new MessageType("Share Something", "explained to", "about");
}