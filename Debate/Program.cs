

Classroom TheGreatDebate = new Classroom();
DebatePerson valdemar = new DebatePerson("Valdemar", DebatePreparation.ReadingSome);
DebatePerson emil = new DebatePerson("Emil", DebatePreparation.ReadingSome);
DebatePerson oscar = new DebatePerson("Oscar", DebatePreparation.ReadingNone);
Console.WriteLine(valdemar);
Console.WriteLine(emil);
Console.WriteLine(oscar);
TheGreatDebate.Discussion(emil, oscar);
TheGreatDebate.Discussion(emil, valdemar);
TheGreatDebate.Discussion(oscar, valdemar);

//TOURNAMENT 
DebatePerson[] participants = {
    emil,
    oscar,
    valdemar,
    new DebatePerson ("Odysseus", DebatePreparation.ReadingAll),
    new DebatePerson ("Amadeus", DebatePreparation.ReadingAll),
};

// each participant debates every other participant twice
for (int i = 0; i < 2; i++)
{
    foreach (DebatePerson person1 in participants)
    {
        foreach (DebatePerson person2 in participants)
        {
            if (person1 != person2)
            {
                TheGreatDebate.Discussion(person1, person2);
            }
        }
    }
}

//Debate over. Sorting participant array by the ArgumentWins property value. 
Array.Sort(participants, delegate (DebatePerson x, DebatePerson y)
{
    return x.ArgumentWins.CompareTo(y.ArgumentWins);
});

Console.WriteLine("\n\n FINAL RANKINGS\n----------------");
for (int i = 0; i < participants.Length; i++)
{
    Console.WriteLine(participants[i]);
}


