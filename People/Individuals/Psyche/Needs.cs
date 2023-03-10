using System.Collections.Generic;
using System.Linq;

[Requestable]
[Rankable]
public struct Needs
{
    public ExistenceNeeds Existence { get; set; }
    public RelatednessNeeds Relatedness { get; set; }
    public GrowthNeeds Growth { get; set; }

    public Needs(ExistenceNeeds existence, RelatednessNeeds relatedness, GrowthNeeds growth)
    {
        Existence = existence;
        Relatedness = relatedness;
        Growth = growth;
    }
}

[Requestable]
[Rankable]
[Reducible]
public struct ExistenceNeeds
{
    public Need Food { get; set; }
    public Need Water { get; set; }
    public Need Sleep { get; set; }
    public Need Reproduction { get; set; }
    public Need Shelter { get; set; }
    public Need Security { get; set; }
}


[Requestable]
[Rankable]
[Reducible]
public struct RelatednessNeeds
{
    public Need Friendship { get; set; }
    public Need Love { get; set; }
    public Need Intimacy { get; set; }
    public Need Family { get; set; }
}

[Requestable]
[Rankable]
[Reducible]
public struct GrowthNeeds
{
    public Need Respect { get; set; }
    public Need SelfEsteem { get; set; }
    public Need Status { get; set; }
    public Need Recognition { get; set; }
    public Need Freedom { get; set; }
    public Need Achievement { get; set; }
    public Need Autonomy { get; set; }
}

[Requestable]
[Reducible]
public class Need
{
    public float Importance { get; set; }
    public float Fulfilled { get; set; }
    public float CurrentPressure => Importance * Fulfilled;
}