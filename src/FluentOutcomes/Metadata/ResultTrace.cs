using System.Linq;
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
                ? MainSettings.Instance.AllCorrectMessage
                : Error.Exception.Message;
        }

        internal ResultTrace()
        {
            Metadata = new Dictionary<string, object>();
        }

        internal void AssertMetadata(string metadataName, object metadataValue, bool isSuccess, AssertLevel assertLevel = AssertLevel.Default)
        {
            switch(assertLevel)
            {
                case AssertLevel.FailureOnly:
                {
                    if(isSuccess)
                        break;

                    Metadata.Add(metadataName, metadataValue);
                    break;
                }
                case AssertLevel.SuccessOnly:
                {
                    if(!isSuccess)
                        break;

                    Metadata.Add(metadataName, metadataValue);
                    break;
                }
                default:
                {
                    Metadata.Add(metadataName, metadataValue);
                    break;
                }
            }
        }

        internal void ApplyMetadataSetting(bool isSuccess)
        {
            if(MainSettings.Instance.UsingStatusResultMetadata)
            {
                Metadata.Add("Status", isSuccess ? "Success" : "Failed");
            }

            if(MainSettings.Instance.UsingVerdictMetadata)
            {
                Metadata.Add("Verdict", Verdict);
            }

            MainSettings.Instance.PrefaceMetadata.ToList()
                .ForEach(x => Metadata.Add(x.Key, x.Value));
        }
    }
}