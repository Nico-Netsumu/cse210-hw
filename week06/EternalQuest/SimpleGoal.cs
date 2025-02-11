class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

    public override void RecordProgress()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"The goal '{Name}' has been  completed! You earned {Points} exp points!");
        }
    }
    
    public override string GetSaveString()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsCompleted}";
    }
}
