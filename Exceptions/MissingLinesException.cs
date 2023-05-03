namespace Exceptions
{
    public class MissingLinesException : Exception
    {
        public MissingLinesException()
        { }

        public MissingLinesException(string message)
            : base(message)
        { }

        public MissingLinesException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
