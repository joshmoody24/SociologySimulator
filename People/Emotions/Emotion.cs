using System.Collections.Generic;
using System.Linq;

public class Emotion : Enumeration
{

    public HashSet<Emotion> ComposedOf { get; set; }

    public Emotion(string name, HashSet<Emotion> composedOf) : base(name)
    {
        ComposedOf = composedOf;
    }

    // primary emotions
    public static readonly Emotion Anger = new Emotion("Anger", new HashSet<Emotion>());
    public static readonly Emotion Anticipation = new Emotion("Anticipation", new HashSet<Emotion>());
    public static readonly Emotion Joy = new Emotion("Joy", new HashSet<Emotion>());
    public static readonly Emotion Trust = new Emotion("Trust", new HashSet<Emotion>());
    public static readonly Emotion Fear = new Emotion("Fear", new HashSet<Emotion>());
    public static readonly Emotion Surprise = new Emotion("Surprise", new HashSet<Emotion>());
    public static readonly Emotion Sadness = new Emotion("Sadness", new HashSet<Emotion>());
    public static readonly Emotion Disgust = new Emotion("Disgust", new HashSet<Emotion>());

    // seconary emotions
    public static readonly Emotion Aggression = new Emotion("Aggression", new HashSet<Emotion>() { Anger, Anticipation });
    public static readonly Emotion Pride = new Emotion("Pride", new HashSet<Emotion>() { Anger, Joy });
    public static readonly Emotion Dominance = new Emotion("Dominance", new HashSet<Emotion>() { Anger, Trust });
    public static readonly Emotion Frozenness = new Emotion("Frozenness", new HashSet<Emotion>() { Anger, Fear });
    public static readonly Emotion Outrage = new Emotion("Outrage", new HashSet<Emotion>() { Anger, Surprise });
    public static readonly Emotion Envy = new Emotion("Envy", new HashSet<Emotion>() { Anger, Sadness });
    public static readonly Emotion Contempt = new Emotion("Contempt", new HashSet<Emotion>() { Anger, Disgust });
    public static readonly Emotion Optimism = new Emotion("Optimism", new HashSet<Emotion>() { Anticipation, Joy });
    public static readonly Emotion Hope = new Emotion("Hope", new HashSet<Emotion>() { Anticipation, Trust });
    public static readonly Emotion Anxiety = new Emotion("Anxiety", new HashSet<Emotion>() { Anticipation, Fear });
    public static readonly Emotion Confusion = new Emotion("Confusion", new HashSet<Emotion>() { Anticipation, Surprise });
    public static readonly Emotion Pessimism = new Emotion("Pessimism", new HashSet<Emotion>() { Anticipation, Sadness });
    public static readonly Emotion Cynicism = new Emotion("Cynicism", new HashSet<Emotion>() { Anticipation, Disgust });
    public static readonly Emotion Love = new Emotion("Love", new HashSet<Emotion>() { Joy, Trust });
    public static readonly Emotion Guilt = new Emotion("Guilt", new HashSet<Emotion>() { Joy, Fear });
    public static readonly Emotion Delight = new Emotion("Delight", new HashSet<Emotion>() { Joy, Surprise });
    public static readonly Emotion Bittersweetness = new Emotion("Bittersweetness", new HashSet<Emotion>() { Joy, Sadness });
    public static readonly Emotion Morbidness = new Emotion("Morbidness", new HashSet<Emotion>() { Joy, Disgust });
    public static readonly Emotion Submission = new Emotion("Submission", new HashSet<Emotion>() { Trust, Fear });
    public static readonly Emotion Curiosity = new Emotion("Curiosity", new HashSet<Emotion>() { Trust, Surprise });
    public static readonly Emotion Sentimentality = new Emotion("Sentimentality", new HashSet<Emotion>() { Trust, Sadness });
    public static readonly Emotion Ambivalence = new Emotion("Ambivalence", new HashSet<Emotion>() { Trust, Disgust });
    public static readonly Emotion Awe = new Emotion("Awe", new HashSet<Emotion>() { Fear, Surprise });
    public static readonly Emotion Despair = new Emotion("Despair", new HashSet<Emotion>() { Fear, Sadness });
    public static readonly Emotion Shame = new Emotion("Shame", new HashSet<Emotion>() { Fear, Disgust });
    public static readonly Emotion Disapproval = new Emotion("Disapproval", new HashSet<Emotion>() { Surprise, Sadness });
    public static readonly Emotion Unbelief = new Emotion("Unbelief", new HashSet<Emotion>() { Surprise, Disgust });
    public static readonly Emotion Remorse = new Emotion("Remorse", new HashSet<Emotion>() { Sadness, Disgust });
}