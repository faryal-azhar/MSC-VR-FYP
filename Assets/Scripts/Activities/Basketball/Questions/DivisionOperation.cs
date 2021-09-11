using UnityEngine;

namespace KidsVR.Activities.Basketball.Questions
{
    public class DivisionOperation : IMathOperation
    {
        public MathQuestion CreateQuestion(int min, int max)
        {
            // build the question from the answer so it always divides evenly
            int answer = Random.Range(min, max);
            int right = Random.Range(min, max);
            return new MathQuestion(answer * right, right, '/', answer);
        }
    }
}
