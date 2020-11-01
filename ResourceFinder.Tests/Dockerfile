FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

# run tests
COPY . ./
RUN dotnet test ./ResourceFinder.Tests -c Release