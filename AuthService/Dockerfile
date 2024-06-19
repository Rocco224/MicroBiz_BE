# Stage 1: Build dell'applicazione
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080

# Copia il file di progetto e esegue il restore dei pacchetti NuGet
COPY AuthService/AuthService.csproj AuthService/
RUN dotnet restore AuthService/AuthService.csproj

# Copia tutto il codice sorgente e builda l'applicazione
COPY AuthService/. AuthService/
RUN dotnet publish AuthService/AuthService.csproj -c Release -o /app/out

# Stage 2: Esecuzione dell'applicazione
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia l'output del build dalla stage precedente
COPY --from=build /app/out ./

# Definisci il punto di ingresso dell'applicazione
ENTRYPOINT ["dotnet", "AuthService.dll"]
