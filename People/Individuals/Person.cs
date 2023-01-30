using System.Collections.Generic;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Values Values { get; set; }
    public Culture Culture { get; set; }
    public Traits Traits { get; set; }
    public Needs Needs { get; set; }
    public HashSet<Emotion> CurrentEmotions { get; set; }
    public Knowledge Knowledge { get; set; }

    public Person(string firstName, string lastName, Culture culture, Traits traits, Knowledge knowledge)
    {
        FirstName = firstName;
        LastName = lastName;
        Culture = culture;
        Values = Culture.Values.Copy();
        Traits = traits;
        CurrentEmotions = new HashSet<Emotion>();
        Knowledge = knowledge;
    }
}