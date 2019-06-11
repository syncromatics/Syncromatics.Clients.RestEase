using System;
using System.Net;

namespace Syncromatics.Clients.RestEase
{
    public class ClientException : Exception
    {
        public ClientException(string message, HttpStatusCode statusCode, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }

    public class ClientException<T> : ClientException
    {
        public ClientException(string message, HttpStatusCode statusCode, T error, Exception innerException = null)
            : base(message, statusCode, innerException)
        {
            Error = error;
        }

        public T Error { get; }
    }
}
