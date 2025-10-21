## Generate solution file

dotnet new sln -o LibreriaDigital.sln

## Generate WebApi project

dotnet new webapi -o LibreriaDigital.WebApi -controllers

## Add project to solution file

dotnet sln add LibreriaDigital.WebApi/LibreriaDigital.WebApi.csproj

## Add Entity Framework NuGets and Other Dependencies

cd LibreriaDigital.WebApi 
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.OpenApi

# Install dotnet EntityFramework

dotnet tool install --global dotnet-ef

# Create Migrations

dotnet ef migrations add InitialCreate --project LibreriaDigital.WebApi

# Build and Get services up with docker-compose

docker-compose up -d --build

# See logs of containers 

docker-compose logs [ container-name ]

# Create and update DB

dotnet ef database update

# Get services down

docker-compose down

# Execute Database with Docker alone

docker run -d --rm  --name mssql-2022-server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=myPass123' -p 1440:1433 mcr.microsoft.com/mssql/server:2022-latest

docker exec -it mssql-2022-server /bin/bash