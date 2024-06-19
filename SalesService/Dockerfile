# Stage 1: Build dell'applicazione
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080

# Copia il file di progetto e esegue il restore dei pacchetti NuGet
COPY SalesService/SalesService.csproj SalesService/
RUN dotnet restore SalesService/SalesService.csproj

# Copia tutto il codice sorgente e builda l'applicazione
COPY SalesService/. SalesService/
RUN dotnet publish SalesService/SalesService.csproj -c Release -o /app/out

# Stage 2: Esecuzione dell'applicazione
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia l'output del build dalla stage precedente
COPY --from=build /app/out ./

# Definisci il punto di ingresso dell'applicazione
ENTRYPOINT ["dotnet", "SalesService.dll"]