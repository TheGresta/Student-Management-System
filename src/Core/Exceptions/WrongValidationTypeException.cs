using Core.Utilities.AspectMessage;

namespace Core.Exceptions
{
    public class WrongValidationTypeException : Exception
    {
        public WrongValidationTypeException() : base(AspectMessages.WrongValidationType)
        {
        }

        public WrongValidationTypeException(string? message) : base(message)
        {
        }

        public WrongValidationTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public static void ThrowIfWrongType(Type argument1, Type argument2)
        {
            if (argument1.IsAssignableFrom(argument2) == false)
                throw new WrongValidationTypeException();
        }
    }
}
