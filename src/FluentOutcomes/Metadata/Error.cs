using System;
using FluentOutcomes.Settings;

namespace FluentOutcomes.Metadata
{
    public sealed class Error
    {
        public Exception Exception { get; set; }

        public Error()
        {
            string message = MainSettings.Instance.DefaultErrorMessage;
            Exception = new Exception(message);
        }

        public Error(Exception exception)
        {
            this.Exception = exception;
        }
    }
}