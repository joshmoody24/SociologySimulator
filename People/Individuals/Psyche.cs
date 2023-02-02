// represents the mental state of a person
using System.Collections.Generic;

public class Psyche {
	public Values Values { get; private set; }
	public Culture Culture { get; private set; }
	public Traits Traits { get; private set; }
	public Needs Needs { get; private set; }
	public HashSet<Emotion> CurrentEmotions { get; private set; }
	public Knowledge Knowledge { get; private set; }

	public Psyche(Culture culture, Traits traits, Knowledge knowledge, Needs needs){
		Culture = culture;
		Traits = traits;
		Knowledge = knowledge;
		Needs = needs;
		Values = Culture.Values.Copy();
		CurrentEmotions = new HashSet<Emotion>();
	}
}