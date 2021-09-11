using UnityEngine;

namespace KidsVR.Activities.Basketball.Questions
{
    public class SubtractionOperation : IMathOperation
    {
        public MathQuestion CreateQuestion(int min, int max)
        {
            int a = Random.Range(min, max);
            int b = Random.Range(min, max);

            // bigger number first so the answer is never negative
            int left = Mathf.Max(a, b);
            int right = Mathf.Min(a, b);
            return new MathQuestion(left, right, '-', left - right);
        }
    }
}
