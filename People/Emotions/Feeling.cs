using System.Collections.Generic;
using System.Linq;

public abstract class Feeling
{
    public static IQueryable<Emotion> GetBaseEmotions(Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Aggression:
                return new HashSet<Emotion>() { Emotion.Anger, Emotion.Aggression }.AsQueryable();
            case Emotion.Pride:
                return new HashSet<Emotion>() { Emotion.Anger, Emotion.Joy }.AsQueryable();
            case Emotion.Dominance:
                return new HashSet<Emotion>() { Emotion.Anger, Emotion.Trust }.AsQueryable();
            case Emotion.Frozenness:
                return new HashSet<Emotion>() { Emotion.Anger, Emotion.Fear }.AsQueryable();
            case Emotion.Outrage:
                return new HashSet<Emotion>() { Emotion.Anger, Emotion.Surprise }.AsQueryable();
            case Emotion.Envy:
                return new HashSet<Emotion>() { Emotion.Anger, Emotion.Sadness }.AsQueryable();
            case Emotion.Optimism:
                return new HashSet<Emotion>() { Emotion.Anticipation, Emotion.Joy }.AsQueryable();
            case Emotion.Hope:
                return new HashSet<Emotion>() { Emotion.Anticipation, Emotion.Trust }.AsQueryable();
            case Emotion.Anxiety:
                return new HashSet<Emotion>() { Emotion.Anticipation, Emotion.Fear }.AsQueryable();
            case Emotion.Confusion:
                return new HashSet<Emotion>() { Emotion.Anticipation, Emotion.Fear }.AsQueryable();
            case Emotion.Pessimism:
                return new HashSet<Emotion>() { Emotion.Anticipation, Emotion.Sadness }.AsQueryable();
            case Emotion.Cynicism:
                return new HashSet<Emotion>() { Emotion.Anticipation, Emotion.Disgust }.AsQueryable();
            case Emotion.Love:
                return new HashSet<Emotion>() { Emotion.Joy, Emotion.Trust }.AsQueryable();
            case Emotion.Guilt:
                return new HashSet<Emotion>() { Emotion.Joy, Emotion.Fear }.AsQueryable();
            case Emotion.Delight:
                return new HashSet<Emotion>() { Emotion.Joy, Emotion.Surprise }.AsQueryable();
            case Emotion.Bittersweetness:
                return new HashSet<Emotion>() { Emotion.Joy, Emotion.Sadness }.AsQueryable();
            case Emotion.Morbidness:
                return new HashSet<Emotion>() { Emotion.Joy, Emotion.Disgust }.AsQueryable();
            case Emotion.Submission:
                return new HashSet<Emotion>() { Emotion.Trust, Emotion.Fear }.AsQueryable();
            case Emotion.Curiosity:
                return new HashSet<Emotion>() { Emotion.Trust, Emotion.Surprise }.AsQueryable();
            case Emotion.Sentimentality:
                return new HashSet<Emotion>() { Emotion.Trust, Emotion.Sadness }.AsQueryable();
            case Emotion.Ambivalence:
                return new HashSet<Emotion>() { Emotion.Trust, Emotion.Disgust }.AsQueryable();
            case Emotion.Awe:
                return new HashSet<Emotion>() { Emotion.Fear, Emotion.Surprise }.AsQueryable();
            case Emotion.Despair:
                return new HashSet<Emotion>() { Emotion.Fear, Emotion.Sadness }.AsQueryable();
            case Emotion.Shame:
                return new HashSet<Emotion>() { Emotion.Fear, Emotion.Disgust }.AsQueryable();
            case Emotion.Disapproval:
                return new HashSet<Emotion>() { Emotion.Surprise, Emotion.Sadness }.AsQueryable();
            case Emotion.Unbelief:
                return new HashSet<Emotion>() { Emotion.Surprise, Emotion.Disgust }.AsQueryable();
            case Emotion.Remorse:
                return new HashSet<Emotion>() { Emotion.Sadness, Emotion.Disgust }.AsQueryable();
            default:
                return new HashSet<Emotion>() { emotion }.AsQueryable();
        }
    }
}