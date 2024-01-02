FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Sinqia.Challenge.API/Sinqia.Challenge.API.csproj", "Source/Sinqia.Challenge.API/"]
COPY ["Source/Sinqia.Challenge.Application/Sinqia.Challenge.Application.csproj", "Source/Sinqia.Challenge.Application/"]
COPY ["Source/Sinqia.Challenge.Infrastructure/Sinqia.Challenge.Infrastructure.csproj", "Source/Sinqia.Challenge.Infrastructure/"]
COPY ["Source/Sinqia.Challenge.Domain/Sinqia.Challenge.Domain.csproj", "Source/Sinqia.Challenge.Domain/"]
RUN dotnet restore "Source/Sinqia.Challenge.API/Sinqia.Challenge.API.csproj"
COPY . .
WORKDIR "/src/Source/Sinqia.Challenge.API"
RUN dotnet build "Sinqia.Challenge.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sinqia.Challenge.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sinqia.Challenge.API.dll"]
