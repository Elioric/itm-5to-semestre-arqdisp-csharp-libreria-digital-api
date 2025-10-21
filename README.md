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

# Build and Get services up with docker-compose

docker-compose up -d --build

# See logs of containers 

docker-compose logs [ container-name ]

# Get services down

docker-compose down