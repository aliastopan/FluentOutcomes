namespace FluentOutcomes;

public interface IOutcome
{
    bool Success { get; }
    bool Failure { get; }
    Error? Error { get; }
    string Verdict { get; }
}

public interface IOutcome<TValue> : IOutcome
{
    TValue Value { get; }
}