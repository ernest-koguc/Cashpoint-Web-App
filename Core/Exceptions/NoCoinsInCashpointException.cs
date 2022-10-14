namespace Core.Exceptions
{
    [Serializable]
    public class NoCoinsInCashpointException : Exception
    {
        public NoCoinsInCashpointException()
        { }

        public NoCoinsInCashpointException(string message)
            : base(message)
        { }

        public NoCoinsInCashpointException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
