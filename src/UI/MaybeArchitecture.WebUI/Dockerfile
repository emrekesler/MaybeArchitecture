#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/UI/MaybeArchitecture.WebUI/MaybeArchitecture.WebUI.csproj", "src/UI/MaybeArchitecture.WebUI/"]
COPY ["src/MaybeArchitecture.Infrastructure/MaybeArchitecture.Infrastructure.csproj", "src/MaybeArchitecture.Infrastructure/"]
COPY ["src/MaybeArchitecture.Core/MaybeArchitecture.Core.csproj", "src/MaybeArchitecture.Core/"]
COPY ["src/Plugins/MovieDataProvider/MaybeArchitecture.Plugins.MovieProvider/MaybeArchitecture.Plugins.MovieProvider.csproj", "src/Plugins/MovieDataProvider/MaybeArchitecture.Plugins.MovieProvider/"]
COPY ["src/Plugins/Mapper/MaybeArchitecture.Mapper/MaybeArchitecture.Mapper.csproj", "src/Plugins/Mapper/MaybeArchitecture.Mapper/"]
COPY ["src/Migrations/MaybeArchitecture.Migrations.SqlServer/MaybeArchitecture.Migrations.SqlServer.csproj", "src/Migrations/MaybeArchitecture.Migrations.SqlServer/"]
COPY ["src/Plugins/Mapper/MaybeArchitecture.Mapper.MapsterImp/MaybeArchitecture.Mapper.MapsterImp.csproj", "src/Plugins/Mapper/MaybeArchitecture.Mapper.MapsterImp/"]
COPY ["src/Migrations/MaybeArchitecture.Migrations.Postgre/MaybeArchitecture.Migrations.Postgre.csproj", "src/Migrations/MaybeArchitecture.Migrations.Postgre/"]
COPY ["src/Plugins/MovieDataProvider/MaybeArchitecture.Plugins.MovieProvider.TmdbJson/MaybeArchitecture.Plugins.MovieProvider.TmdbJson.csproj", "src/Plugins/MovieDataProvider/MaybeArchitecture.Plugins.MovieProvider.TmdbJson/"]
RUN dotnet restore "src/UI/MaybeArchitecture.WebUI/MaybeArchitecture.WebUI.csproj"
COPY . .
WORKDIR "/src/src/UI/MaybeArchitecture.WebUI"
RUN dotnet build "MaybeArchitecture.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MaybeArchitecture.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MaybeArchitecture.WebUI.dll"]