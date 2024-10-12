
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        while (true)
        {
         
            Console.Clear();
            Console.WriteLine(scripture.GetFullScripture());
      
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Congratulations!");
                break; 
            }

            Console.WriteLine("\nPress Enter to hide some words or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }
}

class ScriptureReference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int? endVerse;

    public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetReference()
    {
        if (endVerse.HasValue)
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}";
        }
    }
}

class Word
{
    private string word;
    private bool isHidden;

    public Word(string word)
    {
        this.word = word;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetWord()
    {
        if (isHidden)
        {
            return new string('_', word.Length);
        }
        else
        {
            return word;
        }
    }
}

class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public string GetFullScripture()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word word in words)
        {
            displayedWords.Add(word.GetWord());
        }

        return $"{reference.GetReference()}: {string.Join(" ", displayedWords)}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4); 
        int visibleWordsCount = words.FindAll(words => !words.IsHidden()).Count;
        wordsToHide = Math.Min(wordsToHide, visibleWordsCount);

        int hiddenCount = 0;

        while (hiddenCount < wordsToHide)
        {
            int randomIndex = random.Next(words.Count);

            if (!words[randomIndex].IsHidden())
            {
                words[randomIndex].Hide();
                hiddenCount++;
            }

            if (AllWordsHidden())
            {
                break;
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}