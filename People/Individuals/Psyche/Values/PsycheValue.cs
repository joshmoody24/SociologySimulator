using System.Collections.Generic;
using System.Linq;

public struct PsycheValue : ITyped
{
    public Value Value { get; set; }
    public float Importance { get; set; }
    public float Status { get; set; }
    public float Gap => Importance - Status;
    public object GetCategory => Value;

    public PsycheValue(Value value, float importance, float status)
    {
        Value = value;
        Importance = importance;
        Status = status;
    }
}