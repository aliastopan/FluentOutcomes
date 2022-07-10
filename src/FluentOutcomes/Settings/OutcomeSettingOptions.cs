using System;

namespace FluentOutcomes.Settings
{
    public class OutcomeSettingOptions
    {
        public MetadataSettings Metadata { get; init; }

        public OutcomeSettingOptions()
        {
            Metadata = new MetadataSettings();
        }

        public void SetAllCorrectMessage(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                string warning = "Default OK message cannot be null or empty.";
                throw new InvalidOperationException(warning);
            }

            OutcomeSettings.Instance.AllCorrectMessage = message;
        }

        public void SetDefaultErrorMessage(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                string warning = "Default error message cannot be null or empty.";
                throw new InvalidOperationException(warning);
            }

            OutcomeSettings.Instance.DefaultErrorMessage = message;
        }

        // public void AddMetadataStatusResult()
        // {
        //     OutcomeSettings.Instance.UsingStatusResultMetadata = true;
        // }

        // public void AddMetadataVerdict()
        // {
        //     OutcomeSettings.Instance.UsingVerdictMetadata = true;
        // }

        // public void AddMetadataGlobal(string metadataName, object metadataValue)
        // {
        //     OutcomeSettings.Instance.PrefaceMetadata.Add(metadataName, metadataValue);
        // }
    }
}