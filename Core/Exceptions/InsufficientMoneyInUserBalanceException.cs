namespace Core.Exceptions
{
    [Serializable]
    public class InsufficientMoneyInUserBalanceException : Exception
    {
        public InsufficientMoneyInUserBalanceException()
        { }

        public InsufficientMoneyInUserBalanceException(string message)
            : base(message)
        { }

        public InsufficientMoneyInUserBalanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
