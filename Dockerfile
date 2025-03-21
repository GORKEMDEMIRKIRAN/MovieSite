# Build aşaması
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MovieApp/movieapp/movieapp.csproj", "MovieApp/movieapp/"]
RUN dotnet restore "MovieApp/movieapp/movieapp.csproj"
COPY . .
WORKDIR "/src/MovieApp/movieapp"
RUN dotnet build "movieapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "movieapp.csproj" -c Release -o /app/publish

# Çalıştırma aşaması
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "movieapp.dll"]