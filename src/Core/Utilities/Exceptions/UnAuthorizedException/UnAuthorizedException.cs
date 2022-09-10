namespace Core.Utilities.Exceptions.UnAuthorizedException
{
    public class UnAuthorizedException : SystemException
    {
        public UnAuthorizedException(string message) : base(message)
        {
        }
    }
}