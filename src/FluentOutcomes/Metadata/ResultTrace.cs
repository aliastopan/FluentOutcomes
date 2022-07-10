using System.Collections.Generic;
using FluentOutcomes.Settings;

namespace FluentOutcomes.Metadata
{
    public class ResultTrace
    {
        public Dictionary<string, object> Metadata { get; internal set; }
        public Error? Error { get; internal set; }
        public string Verdict
        {
            get => Error is null
                ? OutcomeSettings.Instance.AllCorrectMessage
                : Error.Exception.Message;
        }

        public ResultTrace()
        {
            Metadata = new Dictionary<string, object>();
        }
    }
}