using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        while (!scripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }

        if (scripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetFullyHiddenText());
            Console.WriteLine("\nAll words are now hidden. Program ending.");
        }
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", _words.Select(word => word.GetDisplayText()))}";
    }

    public string GetFullyHiddenText()
    {
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", _words.Select(word => word.GetFullyHiddenText()))}";
    }

    public void HideRandomWords()
    {
        int wordsToHide = _random.Next(1, 4); // Hide 1-3 words at a time
        for (int i = 0; i < wordsToHide; i++)
        {
            List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
            if (visibleWords.Count == 0)
                break;

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }
}

class Reference
{
    private string _reference;

    public Reference(string reference)
    {
        _reference = reference;
    }

    public string GetDisplayText()
    {
        return _reference;
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
            return _text.Length > 0 ? $"{_text[0]}{new string('_', _text.Length - 1)}" : "";
        return _text;
    }

    public string GetFullyHiddenText()
    {
        return new string('_', _text.Length);
    }
}
