using System;

public struct Values
{

    private float _collectivism;
    private float _uncertaintyAvoidance;
    private float _shortTermOrientation;
    private float _masculinity;
    private float _powerDistance;

    public Values Copy()
    {
        return new Values
        {
            Collectivism = this.Collectivism,
            UncertaintyAvoidance = this.UncertaintyAvoidance,
            ShortTermOrientation = this.ShortTermOrientation,
            Masculinity = this.Masculinity,
            PowerDistance = this.PowerDistance,
        };
    }

    // fundamental cultural differences
    public float Collectivism
    {
        get { return _collectivism; }
        set { _collectivism = Math.Clamp(value, 0f, 1f); }
    }
    public float UncertaintyAvoidance
    {
        get { return _uncertaintyAvoidance; }
        set { _uncertaintyAvoidance = Math.Clamp(value, 0f, 1f); }
    }
    public float Masculinity
    {
        get { return _masculinity; }
        set { _masculinity = Math.Clamp(value, 0f, 1f); }
    }
    public float ShortTermOrientation
    {
        get { return _shortTermOrientation; }
        set { _shortTermOrientation = Math.Clamp(value, 0f, 1f); }
    }
    public float PowerDistance
    {
        get { return _powerDistance; }
        set { _powerDistance = Math.Clamp(value, 0f, 1f); }
    }

    // opposites
    public float Individualism => 1f - Collectivism;
    public float AmbiguityTolerance => 1f - UncertaintyAvoidance;
    public float Femininity => 1f - Masculinity;
    public float LongTermOrientation => 1f - ShortTermOrientation;

    // derivative differences
    public float Law => (Collectivism + UncertaintyAvoidance) / 2f;
    public float Loyalty => (Collectivism + Femininity) / 2f;
    public float Family => Collectivism;
    public float Friendship => Loyalty;
    public float Power => (PowerDistance + Masculinity) / 2f;
    public float Cunning => 1f - Law;
    public float Fairness => Collectivism;
    public float Tradition => UncertaintyAvoidance;
    public float Cooperation => Loyalty;
    public float Stoicism => Masculinity;
    public float Introspection => LongTermOrientation;
    public float Tranquility => (UncertaintyAvoidance + Femininity) / 2f;
    public float Merriment => 1f - Tranquility;
    public float Skill => (Individualism + Power) / 2f;
    public float HardWork => (Masculinity + Skill) / 2f;
    public float Competition => Masculinity;
    public float LeisureTime => (LongTermOrientation + Tranquility) / 2f;
    public float Commerce => (Masculinity + Cunning) / 2f;
    public float Nature => (Tranquility + LongTermOrientation) / 2f;
    public float Peace => (Tranquility + Femininity) / 2f;
    public float Knowledge => (Skill + Cunning) / 2f;
    public float Honesty => (Law + Fairness) / 2f;
    public float Humility => (Cooperation + Introspection) / 2f;
    public float Altruism => Collectivism;
}