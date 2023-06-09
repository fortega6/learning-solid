﻿using System.IO;

public class FilePersistence : ILoader, ISaver
{
    private const string Path = "Assets/Resources/savedFile.txt";

    public void SaveData(float duration)
    {
        var writer = new StreamWriter(Path, true);
        writer.WriteLine(duration);
        writer.Close();
    }

    public float LoadData()
    {
        var reader = new StreamReader(Path);
        var durationString = (reader.ReadToEnd());
        reader.Close();
            
        if (!string.IsNullOrEmpty(durationString))
        {
            return float.Parse(durationString);
        }

        return 0;
            
    }
}