using UnityEngine;

namespace KidsVR.Activities.Basketball.Questions
{
    public class AdditionOperation : IMathOperation
    {
        public MathQuestion CreateQuestion(int min, int max)
        {
            int left = Random.Range(min, max);
            int right = Random.Range(min, max);
            return new MathQuestion(left, right, '+', left + right);
        }
    }
}
