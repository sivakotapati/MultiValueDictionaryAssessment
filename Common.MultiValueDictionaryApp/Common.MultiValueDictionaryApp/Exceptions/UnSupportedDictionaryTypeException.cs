namespace Common.MultiValueDictionaryApp.Exceptions
{
    public class UnSupportedDictionaryTypeException : Exception
    {
        public UnSupportedDictionaryTypeException() { }

        public UnSupportedDictionaryTypeException(string message) : base(message) { }

        public UnSupportedDictionaryTypeException(string message, Exception inner) : base(message, inner) { }
    }
}
