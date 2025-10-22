# Libreria Digital - Arquitectura de Dispositivos Moviles

## Generate solution file

```
dotnet new sln -o LibreriaDigital.sln
```

## Generate WebApi project

```
dotnet new webapi -o LibreriaDigital.WebApi -controllers
```

## Crear csproj inside of each layer

```
dotnet new classlib -n LibreriaDigital.Domain
dotnet new classlib -n LibreriaDigital.Application
dotnet new classlib -n LibreriaDigital.Infrastructure
```

## Add projects to solution file

```
dotnet sln add LibreriaDigital.WebApi/LibreriaDigital.WebApi.csproj
dotnet sln add LibreriaDigital.Domain/LibreriaDigital.Domain.csproj
dotnet sln add LibreriaDigital.Application/LibreriaDigital.Application.csproj
dotnet sln add LibreriaDigital.Infrastructure/LibreriaDigital.Infrastructure.csproj
```

## Add references and dependencies between projects

### Application layer dependencies

```
dotnet add LibreriaDigital.Application/LibreriaDigital.Application.csproj reference LibreriaDigital.Domain/LibreriaDigital.Domain.csproj
```

### Infrastructure layer dependencies

```
dotnet add LibreriaDigital.Infrastructure/LibreriaDigital.Infrastructure.csproj reference LibreriaDigital.Application/LibreriaDigital.Application.csproj
dotnet add LibreriaDigital.Infrastructure/LibreriaDigital.Infrastructure.csproj reference LibreriaDigital.Domain/LibreriaDigital.Domain.csproj
```

### Presentation layer dependencies

```
dotnet add LibreriaDigital.WebApi/LibreriaDigital.WebApi.csproj reference LibreriaDigital.Application/LibreriaDigital.Application.csproj
dotnet add LibreriaDigital.WebApi/LibreriaDigital.WebApi.csproj reference LibreriaDigital.Infrastructure/LibreriaDigital.Infrastructure.csproj
```

## Add Entity Framework NuGets and Other Dependencies

### Packages for Application Layer

```
dotnet add LibreriaDigital.Application/LibreriaDigital.Application.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### Packages for Infrastructure Layer

```
dotnet add LibreriaDigital.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add LibreriaDigital.Infrastructure package Microsoft.EntityFrameworkCore.Tools
dotnet add LibreriaDigital.Infrastructure package Microsoft.EntityFrameworkCore.Design
```

### Packages for Presentation Layer

```
dotnet add LibreriaDigital.WebApi package Swashbuckle.AspNetCore --version 6.6.2
dotnet add LibreriaDigital.WebApi/LibreriaDigital.WebApi.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection
```

## Install dotnet EntityFramework

```
dotnet tool install --global dotnet-ef
```

## Create Migrations

```
dotnet ef migrations add InitialCreate --project LibreriaDigital.Infrastructure
```

## Build and Get services up with docker-compose

```
docker-compose up -d --build
```

## See logs of containers

```
docker-compose logs [ container-name ]
```

## Create and update DB

```
dotnet ef database update
```

## Get services down

```
docker-compose down
```

## Execute Database with Docker alone

```
docker run -d --rm  --name mssql-2022-server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=myPass123' -p 1440:1433 mcr.microsoft.com/mssql/server:2022-latest

docker exec -it mssql-2022-server /bin/bash

mssql$ /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'myPass123' -C -Q "SELECT name FROM sys.databases"

mssql$ /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'myPass123' -C -Q "USE LibreriaDigitalDB; SELECT name FROM sys.tables; SELECT * FROM Books;
```
