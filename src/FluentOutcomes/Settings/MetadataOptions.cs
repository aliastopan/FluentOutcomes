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

        public void AddGlobalMetadata(string metadataName, object metadataValue)
        {
            OutcomeSettings.Instance.PrefaceMetadata.Add(metadataName, metadataValue);
        }
    }
}