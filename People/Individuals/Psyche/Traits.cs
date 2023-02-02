[Requestable]
public struct Traits {

	public Traits(float openness, float conscientiousness, float extraversion, float agreeableness, float neuroticism){
		Openness = new OpennessTraits(openness);
		Conscientiousness = new ConscientiousnessTraits(conscientiousness);
		Extraversion = new ExtraversionTraits(extraversion);
		Agreeableness = new AgreeablenessTraits(agreeableness);
		Neuroticism = new NeuroticismTraits(neuroticism);
	}
	
	public OpennessTraits Openness {get;set;}
	public ConscientiousnessTraits Conscientiousness {get;set;}
	public ExtraversionTraits Extraversion {get;set;}
	public AgreeablenessTraits Agreeableness {get;set;}
	public NeuroticismTraits Neuroticism {get;set;}
}

[Requestable]
[Reducible]
public struct OpennessTraits {
	
	public OpennessTraits(float openness){
		Imagination = openness;
		ArtisticTendency = openness;
		Humor = openness;
		Zaniness = openness;
		Hopeful = openness;
		Curiosity = openness;
		Openmindedness = openness;
		Tolerance = openness;
		SwayedByEmotion = openness;
	}
	
	public float Imagination {get;set;}
	public float ArtisticTendency {get;set;}
	public float Humor {get;set;}
	public float Zaniness {get;set;}
	public float Hopeful {get;set;}
	public float Curiosity {get;set;}
	public float Openmindedness {get;set;}
	public float Tolerance {get;set;}
	public float SwayedByEmotion {get;set;}
}

[Requestable]
[Reducible]
public struct ConscientiousnessTraits {

	public ConscientiousnessTraits(float conscientiousness){
		Perseverance = conscientiousness;
		Bravery = conscientiousness;
		Confidence = conscientiousness;
		Ambition = conscientiousness;
		Dutifulness = conscientiousness;
		Singlemindedness = conscientiousness;
		Pride = conscientiousness;
		Perfectionism = conscientiousness;
	}
	
	public float Perseverance {get;set;}
	public float Bravery {get;set;}
	public float Confidence {get;set;}
	public float Ambition {get;set;}
	public float Dutifulness {get;set;}
	public float Singlemindedness {get;set;}
	public float Pride {get;set;}
	public float Perfectionism {get;set;}
}

[Requestable]
[Reducible]
public struct ExtraversionTraits {

	public ExtraversionTraits(float extraversion){
		LovePropensity = extraversion;
		HatePropensity = extraversion;
		Assertiveness = extraversion;
		Cheerfulness = extraversion;
		ActivityLevel = extraversion;
		ExcitementSeeking = extraversion;
		Friendliness = extraversion;
		Politeness = extraversion;
	}
	
	public float LovePropensity {get;set;}
	public float HatePropensity {get;set;}
	public float Assertiveness {get;set;}
	public float Cheerfulness {get;set;}
	public float ActivityLevel {get;set;}
	public float ExcitementSeeking {get;set;}
	public float Friendliness {get;set;}
	public float Politeness {get;set;}

}

[Requestable]
[Reducible]
public struct AgreeablenessTraits {

	public AgreeablenessTraits(float agreeableness){
		Greed = agreeableness;
		Discord = agreeableness;
		ReceivesAdvice = agreeableness;
		Trust = agreeableness;
		Modesty = agreeableness;
		Gratitude = agreeableness;
		Stubbornness = agreeableness;
		Altruism = agreeableness;
	}
	
	public float Greed {get;set;}
	public float Discord {get;set;}
	public float ReceivesAdvice {get;set;}
	public float Trust {get;set;}
	public float Modesty {get;set;}
	public float Gratitude {get;set;}
	public float Stubbornness {get;set;}
	public float Altruism {get;set;}

}

[Requestable]
[Reducible]
public struct NeuroticismTraits {

	public NeuroticismTraits(float neuroticism){
		DepressionPropensity = neuroticism;
		AngerPropensity = neuroticism;
		AnxietyPropensity = neuroticism;
		LustPropensity = neuroticism;
		StressVulnerability = neuroticism;
		Immoderation = neuroticism;
		ViolencePropensity = neuroticism;
		Privacy = neuroticism;
	}
	
	public float DepressionPropensity {get;set;}
	public float AngerPropensity {get;set;}
	public float AnxietyPropensity {get;set;}
	public float LustPropensity {get;set;}
	public float StressVulnerability {get;set;}
	public float Immoderation {get;set;}
	public float ViolencePropensity {get;set;}
	public float Privacy {get;set;}
}