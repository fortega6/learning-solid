using UnityEngine;

public class Persistence
{
    private readonly string DurationKey = "duration";
    public float LoadLastDuration()
    {
        return PlayerPrefs.GetFloat(DurationKey);
    }

    public void SaveLastDuration(float duration)
    {
        PlayerPrefs.SetFloat(DurationKey, duration);
        PlayerPrefs.Save();
    }
}
