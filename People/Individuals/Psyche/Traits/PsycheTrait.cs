using System.Collections.Generic;
using System.Linq;

public struct PsycheTrait : ITyped
{
    public Trait Trait { get; set; }
    public float Importance { get; set; }
    public float Status { get; set; }
    public float Gap => Importance - Status;
    public object GetCategory => Trait;

    public PsycheTrait(Trait trait, float importance, float status)
    {
        Trait = trait;
        Importance = importance;
        Status = status;
    }
}