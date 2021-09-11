namespace KidsVR.Activities.Basketball.Questions
{
    public interface IMathOperation
    {
        // min is inclusive, max is exclusive (same as Random.Range)
        MathQuestion CreateQuestion(int min, int max);
    }
}
