using System;

namespace FluentOutcomes.Settings
{
    public static class OutcomeSettings
    {
        public static void Configure(Action<ResultOptions> options)
        {
            var resultOptions = new ResultOptions();
            options?.Invoke(resultOptions);
        }
    }
}