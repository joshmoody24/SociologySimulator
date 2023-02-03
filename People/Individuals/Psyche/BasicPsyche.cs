// represents the mental state of a person
using System.Collections.Generic;

public class BasicPsyche {
	public HashSet<PsycheValue> Values { get; private set; }
    // public Culture Culture { get; private set; }
    public HashSet<PsycheTrait> Traits { get; private set; }
    public HashSet<PsycheNeed> Needs { get; private set; }
    // public HashSet<PsycheEmotion> CurrentEmotions { get; private set; }
    // public HashSet<PsycheKnowledge> Knowledge { get; private set; }

	public BasicPsyche(HashSet<PsycheValue> values, HashSet<PsycheTrait> traits, HashSet<PsycheNeed> needs){
        //	Culture = culture;
        Values = values;
        Traits = traits;
        Needs = needs;
	}
}