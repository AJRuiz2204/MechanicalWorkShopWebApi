namespace MechanicalWorkShopWebApi.Domain.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public string Email { get; }

        public DuplicateEmailException(string message)
            : base(message)
        {
        }

        public DuplicateEmailException(string message, string email)
            : base(message)
        {
            Email = email;
        }

        public DuplicateEmailException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}