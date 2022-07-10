using FluentOutcomes.Metadata;

namespace FluentOutcomes
{
    public interface IOutcome
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        ResultTrace ResultTrace { get; }
        bool HasMetadata { get; }

        IOutcome WithMetadata(string metadataName, object metadataValue);
    }

    public interface IOutcome<T> : IOutcome
    {
        T Value { get; }

        new IOutcome<T> WithMetadata(string metadataName, object metadataValue);
    }
}