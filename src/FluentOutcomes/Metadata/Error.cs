using System;

namespace FluentOutcomes.Metadata
{
    public sealed class Error
    {
        public Exception Exception { get; set; }

        public Error()
        {
            string message = "Unspecified error has occurred.";
            Exception = new Exception(message);
        }

        public Error(Exception exception)
        {
            this.Exception = exception;
        }
    }
}