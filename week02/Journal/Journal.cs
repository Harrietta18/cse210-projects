using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToCsv());
            }
        }
        Console.WriteLine($"Journal successfully saved to {file}\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found. Please verify the filename and try again.\n");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            List<string> parts = ParseCsvLine(line);
            if (parts.Count == 3)
            {
                Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(loadedEntry);
            }
        }
        Console.WriteLine($"Journal successfully loaded from {file}\n");
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string currentToken = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentToken += '"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(currentToken);
                currentToken = "";
            }
            else
            {
                currentToken += c;
            }
        }
        result.Add(currentToken);
        return result;
    }
}