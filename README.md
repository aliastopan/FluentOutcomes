# FluentOutcomes

**FluentOutcomes** is a is a lightweight .NET library to wrapper returned object while handling the potential errors that comes with it without throwing an exception and to provide a fluent and intuitive way of dealing with `if-else` statement.

## Overview

FluentOutcome wrapper returned object in `IOutcome` or `IOutcome<T>` interface. The best practice here to prefix a method using `Expect` keyword to mark if the method is returning `IOutcome`.


### Case: Expecting Success
``` csharp
    public IOutcome<User> ExpectGetUser(string username)
    {
        var result = _context.Users.SingleOrDefault(search => search.Username == username);

        return Outcome
            .Expect<User>()                         //  declare the expected type
            .SuccessIf(result is not null)          //  declare if true
            .Otherwise(error => {                   //  else
                error.Exception = new Exception()
            })
            .Return(result);                        // return
    }
```
### Case: Expecting Failure
``` csharp
    public IOutcome ExpectUsernameTaken(string username)
    {
        var result = _context.Users.SingleOrDefault(search => search.Username == username);

        return Outcome
            .Expect()
            .FailureIf(result is not null)
            .WithError(error => {
                string message = "Username is already taken."
                error.Exception = new Exception(message)
            })
            .Return();
    }
```

## NuGet Package

Coming Soon<sup>TM</sup>

## Documentation

Coming Soon<sup>TM</sup>

