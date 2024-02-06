FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["src/Persistence/Persistence.csproj", "src/Persistence/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Presentation/Presentation.csproj", "src/Presentation/"]
COPY ["src/Service.Abstractions/Service.Abstractions.csproj", "src/Service.Abstractions/"]
COPY ["src/Shared/Shared.csproj", "src/Shared/"]
COPY ["src/Services/Services.csproj", "src/Services/"]
COPY ["tests/UnitTests/UnitTests.csproj", "tests/UnitTests/"]
COPY ["tests/IntegrationTests/IntegrationTests.csproj", "tests/IntegrationTests/"]
RUN dotnet restore "src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
