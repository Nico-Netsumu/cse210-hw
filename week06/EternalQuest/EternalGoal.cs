class EternalGoal : Goal
{
    public override void RecordProgress()
    {
        Console.WriteLine($"You recorded progress for '{Name}'. You earned {Points} points.");
    }
    
    public override string GetSaveString()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }
}