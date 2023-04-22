using UnityEngine;

public class Persistence : ILoad, ISave
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