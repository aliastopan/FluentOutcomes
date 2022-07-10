using FluentOutcomes.Metadata;

namespace FluentOutcomes
{
    public interface IOutcome
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }

        // Error? Error { get; }
        // string Verdict { get; }
    }

    public interface IOutcome<T> : IOutcome
    {
        T Value { get; }
    }
}