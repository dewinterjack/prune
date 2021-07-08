FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["prune/prune.csproj", "prune/"]
RUN dotnet restore "prune/prune.csproj"
COPY . .
WORKDIR "/src/prune"
RUN dotnet build "prune.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "prune.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "prune.dll"]
