FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LifeBalance.Api/LifeBalance.Api.csproj", "LifeBalance.Api/"]
RUN dotnet restore "Idp/LifeBalance.Api.csproj"
COPY src/ .
WORKDIR "/src/LifeBalance.Api"
RUN dotnet build "LifeBalance.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LifeBalance.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LifeBalance.Api.dll"]