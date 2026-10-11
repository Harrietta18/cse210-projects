using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Creativity: a library of scriptures loaded from a file.
/// Each line of the file has the format:  Reference | Text
/// If the file is missing or empty, a small built-in library is used.
/// </summary>
public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public ScriptureLibrary(string filePath)
    {
        LoadFromFile(filePath);

        if (_scriptures.Count == 0)
        {
            LoadDefaultScriptures();
        }
    }

    private void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            int separator = line.IndexOf('|');
            if (separator == -1)
            {
                continue;
            }

            string referenceText = line.Substring(0, separator).Trim();
            string scriptureText = line.Substring(separator + 1).Trim();

            try
            {
                Reference reference = Reference.Parse(referenceText);
                _scriptures.Add(new Scripture(reference, scriptureText));
            }
            catch (Exception)
            {
                // Skip malformed lines rather than crashing.
            }
        }
    }

    private void LoadDefaultScriptures()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        ));

        _scriptures.Add(new Scripture(
            new Reference("1 Nephi", 3, 7),
            "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord never giveth commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
        ));

        _scriptures.Add(new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might have; and men are, that they might have joy."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."
        ));
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public int GetScriptureCount()
    {
        return _scriptures.Count;
    }
}