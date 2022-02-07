namespace Common.MultiValueDictionaryApp.Exceptions
{
    public class MemberNotExistsException : Exception
    {
        public MemberNotExistsException() { }

        public MemberNotExistsException(string message) : base(message) { }

        public MemberNotExistsException(string message, Exception inner) : base(message, inner) { }
    }
}
