using System ;

    // Class to represent a scripture reference
public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; } // Nullable for single verse

    // Constructor for a single verse
    public Reference(string book, int chapter, int startVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = null;
    }

    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

        public override string ToString()
        {
            return EndVerse.HasValue
                ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}"
                : $"{Book} {Chapter}:{StartVerse}";
        }
}

    // Class to represent a word in the scripture
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    // Class to represent the scripture
    public class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> Words;

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords()
        {
            var random = new Random();
            var wordsToHide = Words.Where(word => !word.IsHidden).ToList();

            if (wordsToHide.Count > 0)
            {
                int wordsToHideCount = Math.Min(2, wordsToHide.Count); // Must hide 2 words per input.
                for (int i = 0; i < wordsToHideCount; i++)
                {
                    var word = wordsToHide[random.Next(wordsToHide.Count)];
                    word.Hide();
                }
            }
        }

        public bool AreAllWordsHidden()
        {
            return Words.All(word => word.IsHidden);
        }

        public override string ToString()
        {
            return $"{Reference}\n{string.Join(" ", Words)}";
        }
    }