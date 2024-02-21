using System;
using System.Net;

namespace Accredit.Challenge.Borders.Exceptions
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public RepositoryException(string errorMessage, HttpStatusCode statusCode) : base(errorMessage)
        {
            StatusCode = statusCode;
        }
    }
}
