FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Usar la imagen SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY ["./LibreriaDigital.WebApi/*.csproj", "LibreriaDigital.WebApi/"]
COPY ["./LibreriaDigital.Application/*.csproj", "LibreriaDigital.Application/"]
COPY ["./LibreriaDigital.Domain/*.csproj", "LibreriaDigital.Domain/"]
COPY ["./LibreriaDigital.Infrastructure/*.csproj", "LibreriaDigital.Infrastructure/"]

RUN dotnet restore "LibreriaDigital.WebApi/LibreriaDigital.WebApi.csproj"
COPY . .
WORKDIR "/src/LibreriaDigital.WebApi"
RUN dotnet build "LibreriaDigital.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibreriaDigital.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibreriaDigital.WebApi.dll"]