## Create a solution 


## Init git
```sh
git config --global core.autocrlf 
git clone git@github.com:Jallalbrahimi/dotnetwebapp.git
git remote set-url origin git@github.com:Jallalbrahimi/dotnetwebapp.git
```


```sh
mkdir src
cd src
dotnet new sln -n WebApp
```

## Create the projects and add them to the solution
```sh
dotnet new web -n WebApp.Api
dotnet new classlib -n WebApp.Domain
dotnet new classlib -n WebApp.Application
dotnet new classlib -n WebApp.Infrastructure

dotnet sln WebApp.sln add WebApp.Api WebApp.Application WebApp.Domain WebApp.Infrastructure
```

## Add references between projects
```sh
dotnet add WebApp.Api reference WebApp.Domain WebApp.Application WebApp.Infrastructure
dotnet add WebApp.Application reference WebApp.Domain
dotnet add WebApp.Infrastructure reference WebApp.Domain
dotnet add WebApp.Infrastructure reference WebApp.Application 
```

## Add assemblies to the projects
```sh
dotnet add WebApp.Application package Microsoft.Extensions.DependencyInjection
dotnet add WebApp.Application package Microsoft.Extensions.Logging.Abstractions
dotnet add WebApp.Application package FluentValidation
dotnet add WebApp.Api package Microsoft.EntityFrameworkCore.Design
dotnet add WebApp.Api package Swashbuckle.AspNetCore
```

## EF Core and SQL Server Provider
```sh
dotnet add WebApp.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add WebApp.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite
dotnet add WebApp.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add WebApp.Infrastructure package Microsoft.Extensions.Configuration.FileExtensions
dotnet add WebApp.Infrastructure package Microsoft.Extensions.Configuration.Json
dotnet add WebApp.Api package Microsoft.EntityFrameworkCore.Design
```

## Init EF Core
```sh
dotnet tool update --global dotnet-ef

# To create the first migration (from the solution directory)
dotnet ef migrations add InitialCreate --verbose --project WebApp.Infrastructure --context WebApp.Infrastructure.Persistence.ApplicationDbContext --startup-project WebApp.Api

# To update the migrations
dotnet ef database update --verbose --project WebApp.Infrastructure --context WebApp.Infrastructure.Persistence.ApplicationDbContext --startup-project WebApp.Api
```

## Links
https://medium.com/@paveluzunov/the-easiest-way-to-replace-mediatr-cb6a0fa07ded

