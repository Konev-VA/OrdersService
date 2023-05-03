namespace Exceptions
{
    public class IncorrectLinesQuantityException : Exception
    {
        public IncorrectLinesQuantityException()
        { }

        public IncorrectLinesQuantityException(string message)
            : base(message)
        { }

        public IncorrectLinesQuantityException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
