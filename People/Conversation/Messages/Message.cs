using System.Collections.Generic;
using System.Linq;

public class Message
{
	// todo: won't need message type (just 'requested data')
	public MessageType Type;
	public Person Speaker { get; set; }
	public Person Receiver { get; set; }
	public List<string> Query { get; set; }
	public float Quality { get; set; }
	public Message ResponseTo {get;set;}
	public QueryStepType EndingStep { get; set; }

	public Message(Person speaker, Person recipient, List<string> query, MessageType type, QueryStepType endingStep, Message responseTo = null)
    {
		Type = type;
		Speaker = speaker;
		Receiver = recipient;
		Query = query;
		ResponseTo = responseTo;
		Quality = 1f;
		EndingStep = endingStep;
	}

	public string QueryString()
	{
		return string.Join("->", Query);
	}

	public override string ToString()
	{
			return Speaker.Name + " " + Type.Verb + " " + Receiver.Name + " " + Type.Description + " " + QueryString();
	}
}