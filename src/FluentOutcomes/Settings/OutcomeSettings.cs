using System;
using System.Collections.Generic;

namespace FluentOutcomes.Settings
{
    internal sealed class OutcomeSettings
    {
        private static readonly Lazy<OutcomeSettings> lazy = new(() => new OutcomeSettings());
        public static OutcomeSettings Instance => lazy.Value;

        public string AllCorrectMessage { get; set; } = "OK.";
        public string DefaultErrorMessage { get; set; } = "Unspecified error has occurred.";
        public bool UsingPrefaceMetadata { get; set; } = true;
        public Dictionary<string, object> PrefaceMetadata { get; set; }

        private OutcomeSettings()
        {
            PrefaceMetadata = new Dictionary<string, object>();
        }
    }
}