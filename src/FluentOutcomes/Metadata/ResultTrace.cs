using System.Linq;
using System.Collections.Generic;
using FluentOutcomes.Settings;

namespace FluentOutcomes.Metadata
{
    public class ResultTrace
    {
        public Dictionary<string, object> Metadata { get; internal set; }
        public Error Error { get; internal set; }
        public string Verdict
        {
            get => Error is null
                ? OutcomeSettings.Instance.AllCorrectMessage
                : Error.Exception.Message;
        }

        internal ResultTrace()
        {
            Metadata = new Dictionary<string, object>();
        }

        internal void ApplyMetadataSetting(bool isSuccess)
        {
            AssertStatusResultMetadata(isSuccess);
            AssertVerdictMetadata(isSuccess);

            OutcomeSettings.Instance.PrefaceMetadata.ToList()
                .ForEach(preface => {
                    AssertMetadata(preface.MetadataName, preface.MetadataValue, isSuccess, preface.AssertLevel);
                });
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

        private void AssertStatusResultMetadata(bool isSuccess)
        {
            if(OutcomeSettings.Instance.UsingStatusResultMetadata)
            {
                Metadata.Add("Status", isSuccess ? "Success" : "Failed");
            }
        }

        private void AssertVerdictMetadata(bool isSuccess)
        {
            if(OutcomeSettings.Instance.UsingVerdictMetadata)
            {
                Metadata.Add("Verdict", Verdict);
            }
        }
    }
}