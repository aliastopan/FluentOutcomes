# FluentOutcomes
![Nuget](https://img.shields.io/nuget/v/FluentOutcomes)
![Nuget](https://img.shields.io/nuget/dt/FluentOutcomes?style=flat)
![GitHub](https://img.shields.io/github/license/einharan/fluentoutcomes)

FluentOutcomes is a lightweight .NET library to wrap a returning object while handling the potential errors that comes with it without throwing an exception and to provide a fluent and declarative way of dealing with `if-else` statement.

## NuGet Package

```
dotnet add package FluentOutcomes --version 2.1.0
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

### Overwrite return value
By default when the outcome `IsFailure` it will return `T Value` as `default!` but it can be overwritten to return the value regardless the result.
``` csharp
var message = "Bar";
var foo = Outcome
    .Expect<string>()
    .FailureIf(message == "Bar")        // fail
    .Otherwise()
    .Return(message, overwrite: true);  // keep return "Bar" regardless
```

### Immediate return **OK** and **Fail**
``` csharp
var foo = Outcome.Ok();
var bar = Outcome.Ok<string>("OK");
var baz = Outcome.Fail();
var qux = Outcome.Fail(new Error());
var led = Outcome.Fail(error => { error.Exception = new Exception(); });
var bam = Outcome.Fail<string>("Fail");
var dim = Outcome.Fail<string>("Fail", new Error());
var cok = Outcome.Fail<string>("Fail", error => { error.Exception = new Exception(); });
```
## Fluent Boolean Operation

### Using **IfNot**, **Or**, **And**, **OrNot**, and **AndNot**
``` csharp
IOutcome<string> outcome = Outcome
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

**Note**: Please aware that using a long chain of complex boolean operation might resulting unpredicted output. Since the the operation was calculate against the previous condition, the precedence and order of evaluation was ignored. As for that scenario you can use [anonymous method](#func-delegate) instead.

``` csharp
.SuccessIfNot(true)
    .Or(true)
    .And(true)
    .OrNot(false)
    .AndNot(true)
```
The boolean chain above is equal to:
``` csharp
(((!true || true) && true) || !false) && !true
```

It would be more intuitive and predicatable result if **Or()** operation is chain to **FailureIf()** clause, where **And()** is chain to **SuccessIf()**.

### Would return **IsFailure** is any of the following string is an empty string.
``` csharp
IOutcome<string> foo = Outcome
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

### Would only return **IsSucsess** if all string is matched.
``` csharp
IOutcome<string> bar = Outcome
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

### Func delegate
In the case of complex boolean operation, you can use lamda expression as argument.
``` csharp
IOutcome<string> foo = Outcome
    .Expect<string>()
    .SuccessIf(() => {
        bool condition = true && (false || false);
        return condition;
    })
        .And(() => {
            return (true && true) || false;
        })
    .Otherwise()
    .Return("Hello, World");
```

``` csharp
return Outcome
    .Expect<string>()
    .SuccessIf(true)
    .Otherwise()
    .Return(() => {
        return "I don't know why would you return something like this, but here you go.";
    });
```