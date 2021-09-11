using System;

namespace KidsVR.Activities.Basketball.Questions
{
    public static class MathOperationFactory
    {
        public static IMathOperation Create(OperationType type)
        {
            switch (type)
            {
                case OperationType.Addition: return new AdditionOperation();
                case OperationType.Subtraction: return new SubtractionOperation();
                case OperationType.Multiplication: return new MultiplicationOperation();
                case OperationType.Division: return new DivisionOperation();
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
