using System.Collections.Generic;
using System.Linq;

public struct PsycheNeed : ITyped
{
    public Need Need { get; set; }
    public float Importance { get; set; }
    public float Status { get; set; }
    public float Gap => Importance - Status;
    public object GetCategory => Need;

    public PsycheNeed(Need need, float importance, float status)
    {
        Need = need;
        Importance = importance;
        Status = status;
    }
}