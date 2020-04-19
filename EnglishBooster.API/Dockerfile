FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EnglishBooster.API.csproj", ""]
RUN dotnet restore "EnglishBooster.API.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "EnglishBooster.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnglishBooster.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnglishBooster.API.dll"]