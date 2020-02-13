using System;
using System.Collections.Generic;
using System.Text;

namespace Perlink.Services.Base
{
    public static class ServiceEnums
    {
        public enum CreateState : short
        {
            /// <summary>
            /// When new account is created on database successfully.
            /// </summary>
            Success = 1,

            /// <summary>
            /// When account already exists.
            /// </summary>
            Exists = 2,

            /// <summary>
            /// When account is not found on database.
            /// </summary>
            NotFound = 3,

            /// <summary>
            /// Error: When error occurs by an internal exception.
            /// </summary>
            InternalError = 9,
        }
    }
}
