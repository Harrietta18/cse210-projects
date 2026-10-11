using System;
using System.Collections.Generic;

/// <summary>
/// Represents a scripture: a reference plus its text broken into words.
/// Knows how to hide words and how to display itself.
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    // Stretch challenge: only words that are still visible can be chosen,
    // so every press of Enter hides NEW words until everything is hidden.
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        int count = Math.Min(numberToHide, visibleWords.Count);
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Creativity: reveal only the FIRST LETTER of a few hidden words
    // to jog the user's memory. Returns how many hints were given.
    public int HintRandomWords(int numberToHint)
    {
        List<Word> hintableWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden() && !word.HasHint())
            {
                hintableWords.Add(word);
            }
        }

        int count = Math.Min(numberToHint, hintableWords.Count);
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(hintableWords.Count);
            hintableWords[index].ShowHint();
            hintableWords.RemoveAt(index);
        }

        return count;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    public int GetHiddenWordCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }

    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        string text = string.Join(" ", displayWords);
        return $"{_reference.GetDisplayText()}\n{text}";
    }
}