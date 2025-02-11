using System;

class Player
{
    public int Score { get; private set; }
    public int Level { get; private set; }

    public Player()
    {
        Score = 0;
        Level = 1;
    }

    public void AddScore(int points)
    {
        Score += points;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int nextLevelThreshold = (Level * 5) + 25;
        while (Score >= nextLevelThreshold)
        {
            Level++;
            Console.WriteLine($"Wow! Now you are at level {Level}!\nPatience +2 !\nPerseverance +3 !\nPunctuality 2+ !");
            break;
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Current Score: {Score}, Current Level: {Level}");
    }
}
