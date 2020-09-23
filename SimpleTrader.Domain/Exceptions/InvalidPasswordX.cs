using System;

namespace StockTrader.Domain.Exceptions
{
    public class InvalidPasswordX : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public InvalidPasswordX(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordX(string message, string username, string password) : base(message)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordX(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }
    }
}
