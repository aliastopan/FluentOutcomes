using System;
using System.Collections.Generic;
using FluentOutcomes.Metadata;

namespace FluentOutcomes.Settings
{
    internal sealed class OutcomeSettings
    {
        private static readonly Lazy<OutcomeSettings> lazy = new Lazy<OutcomeSettings>(() => new OutcomeSettings());
        public static OutcomeSettings Instance => lazy.Value;

        public string AllCorrectMessage { get; internal set; } = "OK";
        public string DefaultErrorMessage { get; internal set; } = "Unspecified error has occurred.";
        public List<PrefaceMetadata> PrefaceMetadata { get; internal set; }
        public bool UsingStatusResultMetadata { get; internal set; } = false;
        public bool UsingVerdictMetadata { get; internal set; } = false;

        private OutcomeSettings()
        {
            PrefaceMetadata = new List<PrefaceMetadata>();
        }
    }
}