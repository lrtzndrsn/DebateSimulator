using System;
public class DebatePerson {
    public int ArgumentWins { get; set; } // Number of won arguments 
    public string Name { get; private set; } //Name of DebatePerson
    public int MaxIntellect { get; private set; } //Max intellect this DebatePerson can have.
    public int Intellect { get; set; } //Current intellect of DebatePerson. Cannot be larger than MaxIntellect. 
    public int StrengthOfArgument { get; private set; } //Current strength of DebatePersons argument.
    public int Semester { get; private set; }  //The current semester of the DebatePerson. 
    public int CounterArgument { get; private set; } //The chance that the DebatePerson will argue back and avoid losing Intellect.
    public int CriticalArgument { get; private set; } //The chance that the DebatePerson will critically argue with the opponent, making the person lose double intellect. 
    public DebatePreparation Preparation { get; set; } //preparation of DebatePerson. 

    private Random rand = new Random();

    public DebatePerson(string name, DebatePreparation preparation) {
        this.Name = name;
        this.Preparation = preparation;
        this.MaxIntellect = 30;
        this.Intellect = 30;
        this.StrengthOfArgument = 3;
        this.Semester = 1;
        this.CounterArgument = 10;
        this.CriticalArgument = 10;

    }

    public override String ToString() {
        return "\nOBJECT PROPERTIES\nName: " + this.Name + "\n" + "Preperation level: " + this.Preparation +
        "\n" + "Max intellect : " + this.MaxIntellect + "\n" + "Intellect level: "
        + this.Intellect + "\n" + "Max strength : " + this.StrengthOfArgument +
        "\n" + "Semester : " + this.Semester + "\n" + "Counter Argument:" + this.CounterArgument +
        "\n" + "Critical Argument: " + +this.CriticalArgument;

    }

    public bool hasLost() {
        if (this.Intellect <= 0) {
            return true;
        } else {
            return false;
        }

    }

    public bool beDrained(int amount) {
        if (this.CounterArgument > this.rand.Next(101)) {
            System.Console.WriteLine(this.Name + " countered the argument, and is not drained lol");
            return false;
        } else {
            System.Console.WriteLine(this.Name + " is drained of " + amount + " points.");
            this.Intellect = this.Intellect - amount;
            return true;
        }

    }

    public void Argue(DebatePerson opponent) {
        if (this.CriticalArgument > this.rand.Next(101)) {
            // striked by double arguments 
            int doubleStrike = 2 * this.StrengthOfArgument;
            opponent.beDrained(doubleStrike);
            System.Console.WriteLine(this.Name + " strikes a double argument at " + opponent.Name + " for " + doubleStrike
            + " points of draining");
        } else {
            opponent.beDrained(this.StrengthOfArgument);
            System.Console.WriteLine(this.Name + " strikes an argument at " + opponent.Name + " for " + StrengthOfArgument
           + " points of draining.");

        }

    }

    public void GetExperience() {
        this.Semester++;
        this.StrengthOfArgument += 2;
        if (this.Preparation == DebatePreparation.ReadingAll) {
            this.MaxIntellect += 10;
        } else {
            this.MaxIntellect += 20;
        }
        if (this.Preparation == DebatePreparation.ReadingSome || this.Preparation == DebatePreparation.ReadingAll) {
            this.CounterArgument += 6;
        } else {
            this.CounterArgument += 3;
        }
        if (this.Preparation == DebatePreparation.ReadingAll) {
            this.CriticalArgument += 6;
        } else {
            this.CriticalArgument += 3;
        }
        Console.WriteLine(this.Name + " has gained experience.");
    }

}


