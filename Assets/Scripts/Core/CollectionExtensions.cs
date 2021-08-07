using System.Collections.Generic;
using UnityEngine;

namespace KidsVR.Core
{
    public static class CollectionExtensions
    {
        // Fisher-Yates shuffle
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
