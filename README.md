# FluentOutcomes

FluentOutcomes is a lightweight .NET library to wrap a returning object while handling the potential errors that comes with it without throwing an exception and to provide a fluent and declarative way of dealing with `if-else` statement.

## NuGet Package

```
    dotnet add package FluentOutcomes --version 2.0.0-beta.2
```

## Overview

FluentOutcome wrapper returned object in `IOutcome` or `IOutcome<T>` interface.
``` csharp
public interface IOutcome
{
    bool IsSuccess { get; }
    bool IsFailure { get; }
    Error? Error { get; }
    string Verdict { get; }     // returning Error.Exception.Message or "OK" when error is null
}

public interface IOutcome<T> : IOutcome
{
    T Value { get; }
}
```
The best practice here to preface a method using `Expect` or `Try` keyword to mark whether the method is returning `IOutcome`.

## Examples

### Expecting using **success** flow if statement
``` csharp
public IOutcome<User> ExpectGetUser(string username)
{
    var result = _context.Users.SingleOrDefault(search => search.Username == username);

    return Outcome
        .Expect<User>()                        //  declare the expected type
        .SuccessIf(result is not null)         //  declare if (expected true value)
        .Otherwise(error => {                  //  else
            error.Exception = new Exception()
        })
        .Return(result!);                      // return User object
}
```
### Expecting using **failure** flow if statement
``` csharp
public IOutcome<User> ExpectGetUser(string username)
{
    var result = _context.Users.SingleOrDefault(search => search.Username == username);

    return Outcome
        .Expect<User>()
        .FailureIf(result is null)
        .WithError(error => {
            string message = $"404";
            error.Exception = new Exception(message)
        })
        .Otherwise()
        .Return(result!);
}
```

### Returning success or failure **immediately**
``` csharp
IOutcome ok = Outcome()
    .Expect()
    .Success();

IOutcome fail = Outcome
    .Expect()
    .Failure(error => {
        error.Exception = new Exception("Something went wrong");
    });
```

### Using **IfNot**, **Or**, **And**, **OrNot**, and **AndNot**
``` csharp
var o = Outcome
    .Expect<string>()
    .SuccessIfNot(true)
        .Or(true)
        .And(true)
        .OrNot(false)
        .AndNot(true)
    .WithError(error => {
        string message = "Wait, what?";
        error.Exception = new Exception(message);
    })
    .Otherwise()
    .Return("Hello, World");
```

``` csharp
var o = Outcome
    .Expect<string>()
    .FailureIf(foo == "")
        .Or(bar == "")
        .Or(baz == "")
        .Or(qux == "")
        .Or(led == "")
        .Or(dim == "")
        .Or(bam == "")
        .Or(cok == "")
    .Otherwise()
    .Return("Hello, World");
```

``` csharp
var o = Outcome
    .Expect<string>()
    .SuccessIf(foo == "Hey,")
        .And(bar == "this")
        .And(baz == "chain")
        .And(qux == "is")
        .And(led == "too")
        .And(dim == "damn")
        .And(bam == "long")
        .And(cok == "!")
    .Otherwise()
    .Return($"{foo} {bar} {baz} {qux} {led} {dim} {bam} {cok}");
```