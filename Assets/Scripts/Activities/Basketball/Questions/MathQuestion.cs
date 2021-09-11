namespace KidsVR.Activities.Basketball.Questions
{
    public struct MathQuestion
    {
        public readonly int Left;
        public readonly int Right;
        public readonly char Symbol;
        public readonly int Answer;

        public MathQuestion(int left, int right, char symbol, int answer)
        {
            Left = left;
            Right = right;
            Symbol = symbol;
            Answer = answer;
        }

        public override string ToString()
        {
            return $"{Left} {Symbol} {Right} = ?";
        }
    }
}
