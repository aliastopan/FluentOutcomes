using System;
using FluentOutcomes.Settings;

namespace FluentOutcomes.Metadata
{
    public sealed class Error
    {
        public Exception Exception { get; set; }

        public Error()
        {
            string message = OutcomeSettings.Instance.DefaultErrorMessage;
            Exception = new Exception(message);
        }

        public Error(string errorMessage)
        {
            Exception = new Exception(errorMessage);
        }

        public Error(Exception exception)
        {
            Exception = exception;
        }
    }
}