using System.Collections.Generic;

namespace FluentOutcomes.Metadata
{
    public class ResultTrace
    {
        public Dictionary<string, object> Metadata { get; internal set; } = new Dictionary<string, object>();
        public Error? Error { get; internal set; }
        public string Verdict => Error is null ? "OK" : Error.Exception.Message;
    }
}