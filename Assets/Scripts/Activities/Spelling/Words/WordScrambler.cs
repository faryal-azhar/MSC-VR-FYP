using KidsVR.Core;

namespace KidsVR.Activities.Spelling.Words
{
    public static class WordScrambler
    {
        // words like "see" can shuffle back into themselves, so try a few times
        private const int MaxAttempts = 10;

        public static string Scramble(string word)
        {
            char[] letters = word.ToCharArray();
            for (int attempt = 0; attempt < MaxAttempts; attempt++)
            {
                letters.Shuffle();
                if (new string(letters) != word) break;
            }
            return new string(letters);
        }
    }
}
