# Stage 1: Build dell'applicazione
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080

# Copia il file di progetto e esegue il restore dei pacchetti NuGet
COPY HRService/HRService.csproj HRService/
RUN dotnet restore HRService/HRService.csproj

# Copia tutto il codice sorgente e builda l'applicazione
COPY HRService/. HRService/
RUN dotnet publish HRService/HRService.csproj -c Release -o out

# Stage 2: Esecuzione dell'applicazione
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia l'output del build dalla stage precedente
COPY --from=build /app/out ./

# Definisci il punto di ingresso dell'applicazione
ENTRYPOINT ["dotnet", "HRService.dll"]
