using System.Collections.Generic;

public abstract class Feeling {
	public static HashSet<Emotion> GetBaseEmotions(Emotion emotion){
		switch(emotion){
			case Emotion.Aggression:
				return new HashSet<Emotion>(){Emotion.Anger, Emotion.Aggression};
			case Emotion.Pride:
				return new HashSet<Emotion>(){Emotion.Anger, Emotion.Joy};
			case Emotion.Dominance:
				return new HashSet<Emotion>(){Emotion.Anger, Emotion.Trust};
			case Emotion.Frozenness:
				return new HashSet<Emotion>(){Emotion.Anger, Emotion.Fear};
			case Emotion.Outrage:
				return new HashSet<Emotion>(){Emotion.Anger, Emotion.Surprise};
			case Emotion.Envy:
				return new HashSet<Emotion>(){Emotion.Anger, Emotion.Sadness};
			case Emotion.Optimism:
				return new HashSet<Emotion>(){Emotion.Anticipation, Emotion.Joy};
			case Emotion.Hope:
				return new HashSet<Emotion>(){Emotion.Anticipation, Emotion.Trust};
			case Emotion.Anxiety:
				return new HashSet<Emotion>(){Emotion.Anticipation, Emotion.Fear};
			case Emotion.Confusion:
				return new HashSet<Emotion>(){Emotion.Anticipation, Emotion.Fear};
			case Emotion.Pessimism:
				return new HashSet<Emotion>(){Emotion.Anticipation, Emotion.Sadness};
			case Emotion.Cynicism:
				return new HashSet<Emotion>(){Emotion.Anticipation, Emotion.Disgust};
			case Emotion.Love:
				return new HashSet<Emotion>(){Emotion.Joy, Emotion.Trust};
			case Emotion.Guilt:
				return new HashSet<Emotion>(){Emotion.Joy, Emotion.Fear};
			case Emotion.Delight:
				return new HashSet<Emotion>(){Emotion.Joy, Emotion.Surprise};
			case Emotion.Bittersweetness:
				return new HashSet<Emotion>(){Emotion.Joy, Emotion.Sadness};
			case Emotion.Morbidness:
				return new HashSet<Emotion>(){Emotion.Joy, Emotion.Disgust};
			case Emotion.Submission:
				return new HashSet<Emotion>(){Emotion.Trust, Emotion.Fear};
			case Emotion.Curiosity:
				return new HashSet<Emotion>(){Emotion.Trust, Emotion.Surprise};
			case Emotion.Sentimentality:
				return new HashSet<Emotion>(){Emotion.Trust, Emotion.Sadness};
			case Emotion.Ambivalence:
				return new HashSet<Emotion>(){Emotion.Trust, Emotion.Disgust};
			case Emotion.Awe:
				return new HashSet<Emotion>(){Emotion.Fear, Emotion.Surprise};
			case Emotion.Despair:
				return new HashSet<Emotion>(){Emotion.Fear, Emotion.Sadness};
			case Emotion.Shame:
				return new HashSet<Emotion>(){Emotion.Fear, Emotion.Disgust};
			case Emotion.Disapproval:
				return new HashSet<Emotion>(){Emotion.Surprise, Emotion.Sadness};
			case Emotion.Unbelief:
				return new HashSet<Emotion>(){Emotion.Surprise, Emotion.Disgust};
			case Emotion.Remorse:
				return new HashSet<Emotion>(){Emotion.Sadness, Emotion.Disgust};
			default:
				return new HashSet<Emotion>(){emotion};
		}
	}
	}