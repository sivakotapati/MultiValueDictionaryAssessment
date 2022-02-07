namespace Common.MultiValueDictionaryApp.Exceptions
{
    public class KeyNotExistsException : Exception
    {
        public KeyNotExistsException() { }

        public KeyNotExistsException(string message) : base(message) { }

        public KeyNotExistsException(string message, Exception inner) : base(message, inner) { }
    }
}
