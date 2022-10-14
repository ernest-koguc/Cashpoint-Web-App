namespace Core.Exceptions
{
    [Serializable]
    public class InsufficientMoneyInCashpointException : Exception
    {
        public InsufficientMoneyInCashpointException()
        { }

        public InsufficientMoneyInCashpointException(string message)
            : base(message)
        { }

        public InsufficientMoneyInCashpointException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
