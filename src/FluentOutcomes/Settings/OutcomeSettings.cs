using System;

namespace FluentOutcomes.Settings
{
    internal sealed class OutcomeSettings
    {
        private static readonly Lazy<OutcomeSettings> lazy = new(() => new OutcomeSettings());
        public static OutcomeSettings Instance => lazy.Value;

        public string AllCorrectMessage { get; set; } = "OK.";
        public string DefaultErrorMessage { get; set; } = "Unspecified error has occurred.";
        public bool UsingPrefaceMetadata { get; set; } = true;

        private OutcomeSettings()
        {

        }
    }
}