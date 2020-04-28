FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy all files
COPY . ./
RUN dotnet restore

# Build
RUN dotnet publish -c Release -o out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out /app
ENTRYPOINT ["dotnet", "PetanquePlanningApi.dll"]