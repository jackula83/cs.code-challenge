FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish ./ResourceFinder -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=0 /app/out .
ENTRYPOINT ["dotnet", "ResourceFinder.dll"]