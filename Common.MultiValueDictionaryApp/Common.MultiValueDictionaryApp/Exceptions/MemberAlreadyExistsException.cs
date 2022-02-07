namespace Common.MultiValueDictionaryApp.Exceptions
{
    public class MemberAlreadyExistsException : Exception
    {
        public MemberAlreadyExistsException() { }

        public MemberAlreadyExistsException(string message) : base(message) { }

        public MemberAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
    }
}

