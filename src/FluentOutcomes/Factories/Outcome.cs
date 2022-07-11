using System;
using FluentOutcomes.Metadata;
using FluentOutcomes.Settings;

namespace FluentOutcomes
{
    public partial class Outcome
    {
        public static void ConfigureSettings(Action<ResultOptions> options)
        {
            var resultOptions = new ResultOptions();
            options?.Invoke(resultOptions);
        }

        public static IOutcome Ok()
        {
            return new Outcome(true);
        }

        public static IOutcome<T> Ok<T>(T value)
        {
            return new Outcome<T>(value, true);
        }

        public static IOutcome Fail()
        {
            return new Outcome(false, new Error());
        }

        public static IOutcome Fail(Error error)
        {
            return new Outcome(false, error);
        }

        public static IOutcome Fail(Action<Error> error)
        {
            return new Outcome(false, error);
        }

        public static IOutcome<T> Fail<T>()
        {
            return new Outcome<T>(default, false, new Error());
        }

        public static IOutcome<T> Fail<T>(T value, bool overwrite = false)
        {
            return new Outcome<T>(overwrite ? value : default, false, new Error());
        }

        public static IOutcome<T> Fail<T>(T value, Error error, bool overwrite = false)
        {
            return new Outcome<T>(overwrite ? value : default, false, error);
        }

        public static IOutcome<T> Fail<T>(T value, Action<Error> error, bool overwrite = false)
        {
            return new Outcome<T>(overwrite ? value : default, false, error);
        }
    }
}