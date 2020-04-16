FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["english-booster.csproj", ""]
RUN dotnet restore "./english-booster.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "english-booster.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "english-booster.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "english-booster.dll"]