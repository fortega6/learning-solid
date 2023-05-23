using UnityEngine;

public class PlayerPrefsPersistence : ILoader, ISaver
{
    private const string DurationKey = "duration";

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