using System;
using System.Linq;

namespace KidsVR.Activities.Spelling.Words
{
    public static class WordList
    {
        private static readonly char[] LineSeparators = { '\r', '\n' };

        public static string[] Parse(string text)
        {
            return text
                .Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().ToLowerInvariant())
                .Where(line => line.Length > 0)
                .ToArray();
        }
    }
}
