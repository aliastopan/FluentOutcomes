using FluentOutcomes.Metadata;

namespace FluentOutcomes.Settings
{
    public sealed class MetadataOptions
    {
        internal MetadataOptions()
        {

        }

        public void AssertStatusResult()
        {
            OutcomeSettings.Instance.UsingStatusResultMetadata = true;
        }

        public void AssertVerdict()
        {
            OutcomeSettings.Instance.UsingVerdictMetadata = true;
        }

        public void AssertGlobalMetadata(string metadataName, object metadataValue, AssertLevel assertLevel = AssertLevel.Default)
        {
            var prefaceMetadata = new PrefaceMetadata(metadataName, metadataValue, assertLevel);
            OutcomeSettings.Instance.PrefaceMetadata.Add(prefaceMetadata);
        }
    }
}