FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SteamSalelist/SteamSalelist.csproj", "SteamSalelist/"]
RUN dotnet restore "SteamSalelist/SteamSalelist.csproj"
COPY . .
WORKDIR "/src/SteamSalelist"
RUN dotnet build "SteamSalelist.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SteamSalelist.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SteamSalelist.dll"]
