using System;

/// <summary>
/// Represents a single word in the scripture. Knows whether it is hidden
/// and how to display itself (as its text or as underscores).
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _showFirstLetter; // True when a hint has revealed the first letter.

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        _showFirstLetter = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
        _showFirstLetter = false;
    }

    // A hint reveals only the first letter while the rest stays hidden.
    public void ShowHint()
    {
        if (_isHidden)
        {
            _showFirstLetter = true;
        }
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public bool HasHint()
    {
        return _showFirstLetter;
    }

    // Returns the word, or underscores matching the letters of the word.
    // Punctuation (quotes, commas, periods) stays visible so the scripture
    // still reads naturally.
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Find the part of the word made of letters/digits.
        int start = 0;
        int end = _text.Length - 1;

        while (start < _text.Length && !char.IsLetterOrDigit(_text[start]))
        {
            start++;
        }

        while (end >= start && !char.IsLetterOrDigit(_text[end]))
        {
            end--;
        }

        if (end < start)
        {
            return _text; // The "word" was only punctuation; leave it alone.
        }

        string leadingPunctuation = _text.Substring(0, start);
        string trailingPunctuation = _text.Substring(end + 1);
        string core = _text.Substring(start, end - start + 1);

        string hiddenCore = new string('_', core.Length);

        if (_showFirstLetter)
        {
            hiddenCore = core[0] + hiddenCore.Substring(1);
        }

        return leadingPunctuation + hiddenCore + trailingPunctuation;
    }
}