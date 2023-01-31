public class Message
{
    public MessageType Type { get; set; }
    public Topic Topic { get; set; }
    public Person Speaker { get; set; }
    public Person Recipient { get; set; }
    public float Information { get; set; }
    public override string ToString()
    {
        return Speaker.Name + " " + Type.Verb + " " + Recipient.Name + " " + Type.Description + " " + Topic;
    }
}