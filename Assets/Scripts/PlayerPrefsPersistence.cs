using UnityEngine;

public class PlayerPrefsPersistence : ISaver, ILoader
{
   public void SaveData(float duration)
   {
      PlayerPrefs.SetFloat("duration", duration);
      PlayerPrefs.Save();
   }

   public float LoadData()
   {
      return PlayerPrefs.GetFloat("duration");
   }
}
