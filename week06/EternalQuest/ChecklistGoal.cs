class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public override void RecordProgress()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            Console.WriteLine($"Progress recorded for '{Name}'. {CurrentCount}/{TargetCount} completed. You earned {Points} points.");
            if (CurrentCount == TargetCount)
            {
                Console.WriteLine($"Bonus achieved! You earned an additional {BonusPoints} points!");
            }
        }
    }
    
    public override string GetSaveString()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{BonusPoints},{TargetCount},{CurrentCount}";
    }
}