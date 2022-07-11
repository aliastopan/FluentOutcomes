using System;
using System.Collections.Generic;

namespace FluentOutcomes.Settings
{
    internal sealed class MainSettings
    {
        private static readonly Lazy<MainSettings> lazy = new(() => new MainSettings());
        public static MainSettings Instance => lazy.Value;

        public string AllCorrectMessage { get; internal set; } = "OK.";
        public string DefaultErrorMessage { get; internal set; } = "Unspecified error has occurred.";
        public Dictionary<string, object> PrefaceMetadata { get; internal set; }
        public bool UsingStatusResultMetadata { get; internal set; } = false;
        public bool UsingVerdictMetadata { get; internal set; } = false;

        private MainSettings()
        {
            PrefaceMetadata = new Dictionary<string, object>();
        }
    }
}