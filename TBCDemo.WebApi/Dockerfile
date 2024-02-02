FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TBCDemo.WebApi/TBCDemo.WebApi.csproj", "TBCDemo.WebApi/"]
RUN dotnet restore "TBCDemo.WebApi/TBCDemo.WebApi.csproj"
COPY . .
WORKDIR "/src/TBCDemo.WebApi"
RUN dotnet build "TBCDemo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TBCDemo.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TBCDemo.WebApi.dll"]
