#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Monolith.News.API/Monolith.News.API.csproj", "src/Monolith.News.API/"]
RUN dotnet restore "src/Monolith.News.API/Monolith.News.API.csproj"
COPY . .
WORKDIR "/src/src/Monolith.News.API"
RUN dotnet build "Monolith.News.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monolith.News.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monolith.News.API.dll"]