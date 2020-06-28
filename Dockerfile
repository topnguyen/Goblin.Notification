# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .

COPY Goblin.Core/Goblin.Core/*.csproj ./Goblin.Core/Goblin.Core/
COPY Goblin.Core/Goblin.Core.Web/*.csproj ./Goblin.Core/Goblin.Core.Web/

COPY src/Cross/Goblin.Notification.Core/*.csproj ./src/Cross/Goblin.Notification.Core/
COPY src/Cross/Goblin.Notification.Mapper/*.csproj ./src/Cross/Goblin.Notification.Mapper/
COPY src/Cross/Goblin.Notification.Share/*.csproj ./src/Cross/Goblin.Notification.Share/

COPY src/Repository/Goblin.Notification.Contract.Repository/*.csproj ./src/Repository/Goblin.Notification.Contract.Repository/
COPY src/Repository/Goblin.Notification.Repository/*.csproj ./src/Repository/Goblin.Notification.Repository/

COPY src/Service/Goblin.Notification.Contract.Service/*.csproj ./src/Service/Goblin.Notification.Contract.Service/
COPY src/Service/Goblin.Notification.Service/*.csproj ./src/Service/Goblin.Notification.Service/

COPY src/Web/Goblin.Notification/*.csproj ./src/Web/Goblin.Notification/

RUN dotnet restore

# copy everything else and build app

COPY Goblin.Core/Goblin.Core/. ./Goblin.Core/Goblin.Core/
COPY Goblin.Core/Goblin.Core.Web/. ./Goblin.Core/Goblin.Core.Web/

COPY src/Cross/Goblin.Notification.Core/. ./src/Cross/Goblin.Notification.Core/
COPY src/Cross/Goblin.Notification.Mapper/. ./src/Cross/Goblin.Notification.Mapper/
COPY src/Cross/Goblin.Notification.Share/. ./src/Cross/Goblin.Notification.Share/

COPY src/Repository/Goblin.Notification.Contract.Repository/. ./src/Repository/Goblin.Notification.Contract.Repository/
COPY src/Repository/Goblin.Notification.Repository/. ./src/Repository/Goblin.Notification.Repository/

COPY src/Service/Goblin.Notification.Contract.Service/. ./src/Service/Goblin.Notification.Contract.Service/
COPY src/Service/Goblin.Notification.Service/. ./src/Service/Goblin.Notification.Service/

COPY src/Web/Goblin.Notification/. ./src/Web/Goblin.Notification/

WORKDIR /source
RUN dotnet publish -c release -o /publish --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /publish
COPY --from=build /publish ./
ENTRYPOINT ["dotnet", "Goblin.Notification.dll"]