using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace KidsVR.HighScores
{
    // Loads and saves high scores as a json file in the persistent data folder.
    public class HighScoreRepository
    {
        private const string FileName = "highscores.json";

        private readonly Dictionary<HighScoreCategory, int> scores = new Dictionary<HighScoreCategory, int>();

        private static string FilePath => Path.Combine(Application.persistentDataPath, FileName);

        public HighScoreRepository()
        {
            Load();
        }

        public int Get(HighScoreCategory category)
        {
            return scores.TryGetValue(category, out int score) ? score : 0;
        }

        public bool TrySubmit(HighScoreCategory category, int score)
        {
            if (score <= Get(category)) return false;

            scores[category] = score;
            Save();
            return true;
        }

        private void Load()
        {
            if (!File.Exists(FilePath)) return;

            try
            {
                var data = JsonUtility.FromJson<SaveData>(File.ReadAllText(FilePath));
                foreach (Entry entry in data.entries)
                {
                    scores[entry.category] = entry.score;
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Could not read high scores: {e.Message}");
            }
        }

        private void Save()
        {
            var data = new SaveData();
            foreach (KeyValuePair<HighScoreCategory, int> pair in scores)
            {
                data.entries.Add(new Entry { category = pair.Key, score = pair.Value });
            }

            File.WriteAllText(FilePath, JsonUtility.ToJson(data, true));
        }

        // JsonUtility can't save a dictionary, so it is stored as a list
        [Serializable]
        private class SaveData
        {
            public List<Entry> entries = new List<Entry>();
        }

        [Serializable]
        private class Entry
        {
            public HighScoreCategory category;
            public int score;
        }
    }
}
