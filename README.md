# Syncromatics.Clients.RestEase

Common implementation of RestEase-based REST clients.

## Quickstart

Add `Syncromatics.Clients.RestEase` package to your project:

```bash
dotnet add package Syncromatics.Clients.RestEase
```

Then use it to instantiate a REST client

```csharp
var client = typeof(IMyRestEaseApi).GetRestClient("https://example.com");
try
{
    return await client.GetThingAsync();
}
catch (ClientException<ProblemDetails> clientExceptionWithProblemDetails)
{
    Console.Error.WriteLine(clientExceptionWithProblemDetails.Error.Title);
}
catch (ClientException clientException)
{
    Console.Error.WriteLine($"{clientException.StatusCode}: {clientException.Message}}");
}
```

## Building

[![Travis](https://img.shields.io/travis/syncromatics/Syncromatics.Clients.RestEase.svg)](https://travis-ci.org/syncromatics/Syncromatics.Clients.RestEase)
[![NuGet](https://img.shields.io/nuget/v/Syncromatics.Clients.RestEase.svg)](https://www.nuget.org/packages/Syncromatics.Clients.RestEase/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Syncromatics.Clients.RestEase.svg)](https://www.nuget.org/packages/Syncromatics.Clients.RestEase/)

This project is class library built with .NET Core. To build:

```bash
dotnet build
```

## Code of Conduct

We are committed to fostering an open and welcoming environment. Please read our [code of conduct](CODE_OF_CONDUCT.md) before participating in or contributing to this project.

## Contributing

We welcome contributions and collaboration on this project. Please read our [contributor's guide](CONTRIBUTING.md) to understand how best to work with us.

## License and Authors

[![GMV Syncromatics Engineering logo](https://secure.gravatar.com/avatar/645145afc5c0bc24ba24c3d86228ad39?size=16) GMV Syncromatics Engineering](https://github.com/syncromatics)

[![license](https://img.shields.io/github/license/syncromatics/Syncromatics.Clients.RestEase.svg)](https://github.com/syncromatics/Syncromatics.Clients.RestEase/blob/master/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/syncromatics/Syncromatics.Clients.RestEase.svg)](https://github.com/syncromatics/Syncromatics.Clients.RestEase/graphs/contributors)

This software is made available by GMV Syncromatics Engineering under the MIT license.