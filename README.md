# SampleApp

A small music catalogue – artists, songs and genres – used as a playground for Entity Framework Core and ASP.NET Core MVC. The same data is reachable from a console menu and from a web page, so you can watch what SQL each of them produces.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-10.0.10-512BD4?logo=nuget&logoColor=white)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91?logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-local-CC2927?logo=microsoftsqlserver&logoColor=white)
![AutoMapper](https://img.shields.io/badge/AutoMapper-16.2.0-BE4A47)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=AtanasG6_SampleApp&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=AtanasG6_SampleApp)

## Projects

```mermaid
flowchart TD
    MVC["SampleApp.Web.MVC"]
    VM["SampleApp.Web.ViewModels"]
    EXP["SampleApp.Experiments"]
    CORE["SampleApp.Core"]
    DATA["SampleApp.Data"]
    DB[("SQL Server")]

    MVC --> VM
    MVC --> CORE
    EXP --> CORE
    CORE --> DATA
    DATA --> DB
```

`SampleApp.Core` never returns an entity to the web layer – it returns a projection, which the controller maps to a view model.

## Domain model

```mermaid
erDiagram
    ARTIST ||--o{ SONG : performs
    SONG }o--o{ GENRE : "belongs to"

    ARTIST {
        Guid Id PK
        string FirstName
        string LastName
        string Nickname
    }
    SONG {
        Guid Id PK
        string Name
        Guid ArtistId FK
    }
    GENRE {
        Guid Id PK
        string Name
    }
```

The join table `GenreSong` has no class of its own – EF Core creates it by convention from the two collection navigations.

## A request

```mermaid
sequenceDiagram
    participant B as Browser
    participant C as GenresController
    participant S as GenreService
    participant R as Genre repository
    participant DB as SQL Server

    B->>C: GET /genres
    C->>S: GetAll()
    S->>R: GetMany(filter, projection, order)
    R->>DB: SELECT Id, Name FROM Genres ORDER BY Name
    DB-->>R: rows
    R-->>S: projections
    S-->>C: projections
    C-->>B: rendered Razor view
```

## Where to look

| Topic | File |
| --- | --- |
| Projections instead of `Include` | `SampleApp.Core/Services` |
| Change tracker states | `SampleApp.Experiments/Program.cs` |
| Migrations vs `EnsureCreated` | `SampleApp.Data/Migrations` |
| Many-to-many by convention | `Song.Genres`, `Genre.Songs` |
| Generic repository with sorting | `SampleApp.Data/Repositories`, `SampleApp.Data/Sorting` |
| Separate input and view models | `SampleApp.Web.ViewModels/Genres` |

## Running it

Needs the [.NET 10 SDK](https://dotnet.microsoft.com/download), SQL Server at `.`, and `dotnet tool install --global dotnet-ef`.

```bash
dotnet ef database update --project SampleApp.Data --startup-project SampleApp.Data -- "Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True"
```

```bash
dotnet run --project SampleApp.Web.MVC
```

The console menu applies the migrations itself and prints every SQL statement it sends:

```bash
dotnet run --project SampleApp.Experiments
```

## Code quality

Analysed by [SonarQube Cloud](https://sonarcloud.io/summary/overall?id=AtanasG6_SampleApp) on every push and pull request.
