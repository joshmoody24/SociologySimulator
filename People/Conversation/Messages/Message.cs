public abstract class Message
{
	public MessageType Type { get; set; }
	public Topic Topic { get; set; }
	public Person Speaker { get; set; }
	public Person Recipient { get; set; }
	public float Quality { get; set; }
	public Message ResponseTo {get;set;}

	public Message(Person speaker, Person recipient, MessageType type, Topic topic, Message responseTo = null){
		Type = type;
		Topic = topic;
		Speaker = speaker;
		Recipient = recipient;
		responseTo = responseTo;
		Quality = 1f;
	}

	public override string ToString()
	{
			return Speaker.Name + " " + Type.Verb + " " + Recipient.Name + " " + Type.Description + " " + Topic;
	}
}