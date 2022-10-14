namespace CashpointWeb.Exceptions
{
    [Serializable]
    public class EmptySqlDatabaseException : Exception
    {
        public EmptySqlDatabaseException()
        { }

        public EmptySqlDatabaseException(string message)
            : base(message)
        { }

        public EmptySqlDatabaseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
