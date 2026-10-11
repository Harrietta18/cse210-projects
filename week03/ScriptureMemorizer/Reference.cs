using System;

/// <summary>
/// Represents a scripture reference such as "John 3:16" or "Proverbs 3:5-6".
/// </summary>
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse, e.g. "John 3:16".
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for a range of verses, e.g. "Proverbs 3:5-6".
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Builds a Reference from a string like "John 3:16", "Proverbs 3:5-6",
    // or "1 Nephi 3:7" (book names may contain spaces and numbers).
    public static Reference Parse(string text)
    {
        int colonIndex = text.IndexOf(':');
        if (colonIndex == -1)
        {
            throw new ArgumentException($"Invalid reference: {text}");
        }

        string beforeColon = text.Substring(0, colonIndex).Trim(); // "Proverbs 3"
        string afterColon = text.Substring(colonIndex + 1).Trim(); // "5-6"

        int lastSpace = beforeColon.LastIndexOf(' ');
        string book = beforeColon.Substring(0, lastSpace).Trim();
        int chapter = int.Parse(beforeColon.Substring(lastSpace + 1));

        int dashIndex = afterColon.IndexOf('-');
        if (dashIndex == -1)
        {
            return new Reference(book, chapter, int.Parse(afterColon));
        }
        else
        {
            int startVerse = int.Parse(afterColon.Substring(0, dashIndex));
            int endVerse = int.Parse(afterColon.Substring(dashIndex + 1));
            return new Reference(book, chapter, startVerse, endVerse);
        }
    }

    // Returns the reference formatted for display, e.g. "John 3:16"
    // or "Proverbs 3:5-6".
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}