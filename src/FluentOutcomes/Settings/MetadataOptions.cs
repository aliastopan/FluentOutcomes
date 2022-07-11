namespace FluentOutcomes.Settings
{
    public sealed class MetadataOptions
    {
        internal MetadataOptions()
        {

        }

        public void AddStatusResult()
        {
            MainSettings.Instance.UsingStatusResultMetadata = true;
        }

        public void AddVerdict()
        {
            MainSettings.Instance.UsingVerdictMetadata = true;
        }

        public void AddGlobalMetadata(string metadataName, object metadataValue)
        {
            MainSettings.Instance.PrefaceMetadata.Add(metadataName, metadataValue);
        }
    }
}