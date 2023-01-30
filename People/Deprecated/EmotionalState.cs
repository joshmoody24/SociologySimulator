public struct EmotionalState
{

    // primary emotions
    public float Anger { get; set; }
    public float Anticipation { get; set; }
    public float Joy { get; set; }
    public float Trust { get; set; }
    public float Fear { get; set; }
    public float Surprise { get; set; }
    public float Sadness { get; set; }
    public float Disgust { get; set; }

    // secondary emotions
    public float Aggression => (Anger + Anticipation) / 2f;
    public float Pride => (Anger + Joy) / 2f;
    public float Dominance => (Anger + Trust) / 2f;
    public float Frozenness => (Anger + Fear) / 2f;
    public float Outrage => (Anger + Surprise) / 2f;
    public float Envy => (Anger + Sadness) / 2f;
    public float Optimism => (Anticipation + Joy) / 2f;
    public float Hope => (Anticipation + Trust) / 2f;
    public float Anxiety => (Anticipation + Fear) / 2f;
    public float Confusion => (Anticipation + Surprise) / 2f;
    public float Pessimism => (Anticipation + Sadness) / 2f;
    public float Cynicism => (Anticipation + Disgust) / 2f;
    public float Love => (Joy + Trust) / 2f;
    public float Guilt => (Joy + Fear) / 2f;
    public float Delight => (Joy + Surprise) / 2f;
    public float Bittersweetness => (Joy + Sadness) / 2f;
    public float Morbidness => (Joy + Disgust) / 2f;
    public float Submission => (Trust + Fear) / 2f;
    public float Curiosity => (Trust + Surprise) / 2f;
    public float Sentimentality => (Trust + Sadness) / 2f;
    public float Ambivalence => (Trust + Disgust) / 2f;
    public float Awe => (Fear + Surprise) / 2f;
    public float Despair => (Fear + Sadness) / 2f;
    public float Shame => (Fear + Disgust) / 2f;
    public float Disapproval => (Surprise + Sadness) / 2f;
    public float Unbelief => (Surprise + Disgust) / 2f;
    public float Remorse => (Sadness + Disgust) / 2f;
}