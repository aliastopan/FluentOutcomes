using FluentOutcomes.Metadata;

namespace FluentOutcomes.Settings
{
    public sealed class MetadataOptions
    {
        internal MetadataOptions()
        {

        }

        public void AddStatusResult()
        {
            OutcomeSettings.Instance.UsingStatusResultMetadata = true;
        }

        public void AddVerdict()
        {
            OutcomeSettings.Instance.UsingVerdictMetadata = true;
        }

        public void AddGlobalMetadata(string metadataName, object metadataValue, AssertLevel assertLevel = AssertLevel.Default)
        {
            var prefaceMetadata = new PrefaceMetadata(metadataName, metadataValue, assertLevel);
            OutcomeSettings.Instance.PrefaceMetadata.Add(prefaceMetadata);
        }
    }
}