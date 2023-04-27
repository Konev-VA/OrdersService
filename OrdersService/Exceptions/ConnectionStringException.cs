namespace OrdersService.Exceptions
{
    public class ConnectionStringException : Exception
    {
        public ConnectionStringException()
        { }

        public ConnectionStringException(string message)
            : base(message)
        { }

        public ConnectionStringException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
