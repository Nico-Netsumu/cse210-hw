// Blank Lina

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.Date);
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
                writer.WriteLine("---"); // Separator for readability
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string date, prompt, response;
            while ((date = reader.ReadLine()) != null)
            {
                prompt = reader.ReadLine();
                response = reader.ReadLine();
                reader.ReadLine(); // Skip separator line
                _entries.Add(new Entry(date, prompt, response));
            }
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }
}
