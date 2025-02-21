using System;
using System.Collections.Generic;
using System.Linq;

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
