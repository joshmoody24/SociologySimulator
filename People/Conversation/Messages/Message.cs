public class Message
{
	// todo: won't need message type (just 'requested data')
	public MessageType Type;
	public Topic Topic { get; set; }
	public Person Speaker { get; set; }
	public Person Receiver { get; set; }
	public float Quality { get; set; }
	public Message ResponseTo {get;set;}

	public Message(Person speaker, Person recipient, MessageType type, Topic topic, Message responseTo = null){
		Type = type;
		Topic = topic;
		Speaker = speaker;
		Receiver = recipient;
		ResponseTo = responseTo;
		Quality = 1f;
	}

	public override string ToString()
	{
			return Speaker.Name + " " + Type.Verb + " " + Receiver.Name + " " + Type.Description + " " + Topic;
	}
}