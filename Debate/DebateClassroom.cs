using System;

public class Classroom
{
    public DebatePerson Discussion(DebatePerson person1, DebatePerson person2)
    {
        int round = 1;

        DebatePerson current;
        DebatePerson inactive;
        // randomly select who should argue first. 
        if (new Random().Next(2) == 0)
        {
            current = person1;
            inactive = person2;
        }
        else
        {
            current = person2;
            inactive = person1;
        }

        //Argue until someone is too drained
        //of Intellect to keep on.
        Console.WriteLine("\n\n" + current.Name + " and " + inactive.Name + " will debate till' drained!!!");

        while (!person1.hasLost() && !person2.hasLost())
        {
            Console.WriteLine("\nROUND: {0}", round);

            //Switch current and inactive 
            DebatePerson temp = current;
            current = inactive;
            inactive = temp;

            // Argue 
            current.Argue(inactive);

            //Increment round number 
            round++;
        }

        // Increment wins counter: 
        current.ArgumentWins++;

        //Announce winner:
        Console.WriteLine("The winner is: " + current.Name);
        current.GetExperience();

        //Restore intellect 
        current.Intellect = current.MaxIntellect;
        inactive.Intellect = inactive.MaxIntellect;

        //Return winner
        return current;

    }


}