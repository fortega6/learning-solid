using System.IO;

namespace DefaultNamespace
{
    public class FilePersistance : ILoader, ISaver
    {
        public void SaveData(float duration)
        {
            string path = "Assets/Resources/savedFile.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(duration);
            writer.Close();
        }

        public float LoadData()
        {
            string path = "Assets/Resources/savedFile.txt";
            StreamReader reader = new StreamReader(path);
            string durationString = (reader.ReadToEnd());
            reader.Close();
            
            if (!string.IsNullOrEmpty(durationString))
            {
                return float.Parse(durationString);
            }

            return 0;
            
        }
    }
}
