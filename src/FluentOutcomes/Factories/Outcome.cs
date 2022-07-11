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
            var result = new Outcome();
            result.IsSuccess = true;
            return result;
        }

        public static IOutcome<T> Ok<T>(T value)
        {
            var result = new Outcome<T>();
            result.IsSuccess = true;
            result.Value = value;
            return result;
        }

        public static IOutcome Fail()
        {
            var result = new Outcome();
            result.IsSuccess = false;
            result.ResultTrace.Error = new Error();
            return result;
        }

        public static IOutcome Fail(Error error)
        {
            var result = new Outcome();
            result.IsSuccess = false;
            result.ResultTrace.Error = error;
            return result;
        }

        public static IOutcome Fail(Action<Error> error)
        {
            Error err = new Error();
            error?.Invoke(err);

            var result = new Outcome();
            result.IsSuccess = false;
            result.ResultTrace.Error = err;
            return result;
        }

        public static IOutcome<T> Fail<T>()
        {
            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = default!;
            result.ResultTrace.Error = new Error();
            return result;
        }

        public static IOutcome<T> Fail<T>(T value, bool overwrite = false)
        {
            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = overwrite ? value : default!;
            result.ResultTrace.Error = new Error();
            return result;
        }

        public static IOutcome<T> Fail<T>(T value, Error error, bool overwrite = false)
        {
            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = overwrite ? value : default!;
            result.ResultTrace.Error = error;
            return result;
        }

        public static IOutcome<T> Fail<T>(T value, Action<Error> error, bool overwrite = false)
        {
            Error err = new Error();
            error?.Invoke(err);

            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = overwrite ? value : default!;
            result.ResultTrace.Error = err;
            return result;
        }
    }
}