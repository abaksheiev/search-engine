# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ScoreEngine.Repositories/ScoreEngine.Repositories.csproj", "ScoreEngine.Repositories/"]
COPY ["ScoreEngine.Domain/ScoreEngine.Domain.csproj", "ScoreEngine.Domain/"]
COPY ["ScoreEngine.Contracts/ScoreEngine.Contracts.csproj", "ScoreEngine.Contracts/"]
COPY ["ScoreEngine.Busness/ScoreEngine.Busness.csproj", "ScoreEngine.Busness/"]
COPY ["ScoreEngine.Init/ScoreEngine.Init.csproj", "ScoreEngine.Init/"]
COPY ["ScoreEngine.Start/ScoreEngine.Start.csproj", "ScoreEngine.Start/"]

RUN dotnet restore "./ScoreEngine.Start/ScoreEngine.Start.csproj"

COPY . .
WORKDIR "/src/ScoreEngine.Start"
RUN dotnet build "./ScoreEngine.Start.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ScoreEngine.Start.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
