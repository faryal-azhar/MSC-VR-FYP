using System;

namespace KidsVR.Activities.Spelling.Words
{
    // Sorted list of valid english words, checked with binary search.
    public class WordDictionary
    {
        private readonly string[] words;

        public WordDictionary(string text)
        {
            words = WordList.Parse(text);
            Array.Sort(words, StringComparer.Ordinal);
        }

        public bool Contains(string word)
        {
            return Array.BinarySearch(words, word.ToLowerInvariant(), StringComparer.Ordinal) >= 0;
        }
    }
}
