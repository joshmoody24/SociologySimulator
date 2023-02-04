using System.Collections.Generic;

public class Conversation {
	public List<Message> History {get;set;}
	public Conversation(){
		History = new List<Message>();
	}
}