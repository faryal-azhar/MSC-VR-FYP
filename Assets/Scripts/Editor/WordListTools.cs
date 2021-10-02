using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KidsVR.EditorTools
{
    // Helpers I used to prepare the word lists for the spelling activity.
    public static class WordListTools
    {
        private const string Folder = "Assets/TextDataFiles";
        private const string FullDictionary = "fullEnglishDictionary.txt";
        private const string CondensedDictionary = "condenseDictionary.txt";
        private const int MinWordLength = 3;
        private const int MaxWordLength = 6;

        private static readonly string[] LevelFiles = { "easy.txt", "medium.txt", "hard.txt" };

        [MenuItem("Tools/Word Lists/Build Condensed Dictionary")]
        private static void BuildCondensedDictionary()
        {
            string[] words = ReadWords(FullDictionary)
                .Where(word => word.Length >= MinWordLength && word.Length <= MaxWordLength)
                .Distinct()
                .OrderBy(word => word, StringComparer.Ordinal)
                .ToArray();

            File.WriteAllLines(Path.Combine(Folder, CondensedDictionary), words);
            AssetDatabase.Refresh();
            Debug.Log($"Condensed dictionary saved with {words.Length} words");
        }

        [MenuItem("Tools/Word Lists/Sort Level Files")]
        private static void SortLevelFiles()
        {
            foreach (string file in LevelFiles)
            {
                string[] words = ReadWords(file).Distinct().OrderBy(word => word, StringComparer.Ordinal).ToArray();
                File.WriteAllLines(Path.Combine(Folder, file), words);
            }
            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Word Lists/Check Level Words")]
        private static void CheckLevelWords()
        {
            var dictionary = new HashSet<string>(ReadWords(CondensedDictionary));
            foreach (string file in LevelFiles)
            {
                string[] missing = ReadWords(file).Where(word => !dictionary.Contains(word)).ToArray();
                if (missing.Length == 0)
                {
                    Debug.Log($"{file}: all words found in the dictionary");
                }
                else
                {
                    Debug.LogWarning($"{file}: not in dictionary -> {string.Join(", ", missing)}");
                }
            }
        }

        private static string[] ReadWords(string fileName)
        {
            return File.ReadAllLines(Path.Combine(Folder, fileName))
                .Select(line => line.Trim().ToLowerInvariant())
                .Where(line => line.Length > 0)
                .ToArray();
        }
    }
}
