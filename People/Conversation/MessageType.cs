public class MessageType : Enumeration
{

    public string Verb { get; private set; }
    public string Description { get; private set; }

    public MessageType(string name, string verb, string description) : base(name)
    {
        Verb = verb;
        Description = description;
    }

    public static MessageType Greeting = new MessageType("Greeting", "greeted", "by talking about");
    public static MessageType Closing = new MessageType("Closing", "bid farewell to", "with a final comment about");
    public static MessageType Instruction = new MessageType("Instruction", "taught", "about");
    public static MessageType Question = new MessageType("Question", "asked", "about");
    public static MessageType Answer = new MessageType("Answer", "answered", "by talking about");
}