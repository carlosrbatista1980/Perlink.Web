using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perlink.Data
{
    public static class DataConstants
    {
        /// <summary>
        /// Reutilizar as mensagens do sistema ia ficar legal mas, vou deixar só algumas
        /// </summary>

        public static class Messages
        {
            public static class Login
            {
                public const string Password = "Password is Required!.";
                public const string Username = "Username is Required!.";
                public const string Email = "Email is Required.";
                public const string LoginSuccess = "Successfully login!";
                public const string LoginError = "Enter a valid Username or Password.";
            }

            public static class Register
            {
                public const string RegisterSuccess = "Successfully created account!";
                public const string RegisterError = "Enter a valid Username or Password.";
                public const string EmailAlreadyExists = "Email already exists!";
                public const string AccountAlreadyExists = " Account name already exists!";
            }

            public static class ApiResponses
            {
                public const string AuthenticationError = "nao implementei o MD5";
                public const string InternalError = "para error genericos";
                public const string Badrequest = "Bad Request!";
                public const string ServiceNotAvailable = "Service is not available";
                public const string ServiceDeprecated = "Service deprecated";
            }
        }
    }
}
