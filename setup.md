## Create a solution 

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

## Add projects to the solution
```sh
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
```

