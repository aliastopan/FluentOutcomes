namespace FluentOutcomes.Metadata
{
    internal sealed class PrefaceMetadata
    {
        public string MetadataName { get; set; }
        public object MetadataValue { get; set; }
        public AssertLevel AssertLevel { get; set; }

        internal PrefaceMetadata(string metadataName, object metadataValue, AssertLevel assertLevel)
        {
            MetadataName = metadataName;
            MetadataValue = metadataValue;
            AssertLevel = assertLevel;
        }
    }
}