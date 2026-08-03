# SampleApp

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)

An ASP.NET Core MVC application for managing a small music catalogue – artists, songs and
genres – built as a layered sample project on .NET 10.

## Tech stack

| Component | Version |
| --- | --- |
| .NET | 10.0 |
| Entity Framework Core (SQL Server) | 10.0.10 |
| AutoMapper | 16.2.0 |

## Project structure

| Project | Responsibility |
| --- | --- |
| `SampleApp.Data` | EF Core `DbContext`, entity models, migrations, generic repository, sorting helpers |
| `SampleApp.Core` | Service layer and read-model projections |
| `SampleApp.Web.ViewModels` | View models shared with the presentation layer |
| `SampleApp.Web.MVC` | Controllers, Razor views, AutoMapper profiles, composition root |
| `SampleApp.Experiments` | Scratch console project for trying things out |

## Domain model

- **Artist** – has many songs
- **Song** – belongs to one artist, has many genres
- **Genre** – has many songs

All entities implement `IIdentifiable` and use `Guid` primary keys.

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express or full) reachable at `.`
- `dotnet-ef` CLI tool:

  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Database

The connection string is currently hardcoded in `SampleApp.Web.MVC/Program.cs`:

```
Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True
```

Adjust it there if your SQL Server instance differs, then apply the migrations. The design
time factory takes the connection string as an argument, and `Microsoft.EntityFrameworkCore.Design`
lives in `SampleApp.Data`, so that project is both the target and the startup project:

```bash
dotnet ef database update --project SampleApp.Data --startup-project SampleApp.Data -- "Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True"
```

### Run

```bash
dotnet run --project SampleApp.Web.MVC
```

## Code quality

Every push to `master` and every pull request is automatically analysed by
[SonarQube Cloud](https://sonarcloud.io/summary/overall?id=AtanasG6_SampleApp) via
Automatic Analysis. Findings are posted directly as pull request comments – no CI
configuration is required.

## Known gaps

- Connection string is not read from `appsettings.json` (see `TODO` in `Program.cs`)
- `Artist` has no repository or service registration yet
- No test projects, so code coverage is not reported
