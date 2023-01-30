using System.Collections.Generic;

public class Knowledge
{
    public Dictionary<Topic, float> TopicKnowledge { get; }

    public Knowledge()
    {
        TopicKnowledge = new Dictionary<Topic, float>();
    }

    public float Of(Topic topic)
    {
        if (TopicKnowledge.ContainsKey(topic)) return TopicKnowledge[topic];
        return 0f;
    }
}