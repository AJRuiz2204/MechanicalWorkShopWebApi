namespace MechanicalWorkShopWebApi.Domain.Exceptions
{
    public class DuplicateUsernameException : Exception
    {
        public string Username { get; }

        public DuplicateUsernameException(string message) 
            : base(message)
        {
        }

        public DuplicateUsernameException(string message, string username) 
            : base(message)
        {
            Username = username;
        }

        public DuplicateUsernameException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}