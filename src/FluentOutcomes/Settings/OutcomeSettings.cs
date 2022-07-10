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
        public Dictionary<string, object> PrefaceMetadata { get; set; }
        public bool UsingStatusResultMetadata { get; set; } = false;
        public bool UsingVerdictMetadata { get; set; } = false;

        private OutcomeSettings()
        {
            PrefaceMetadata = new Dictionary<string, object>();
        }
    }
}