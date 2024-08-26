FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Code/net.webapi/net.webapi.csproj", "Code/net.webapi/"]
RUN dotnet restore "Code/net.webapi/net.webapi.csproj"
COPY . .
WORKDIR "/src/Code/net.webapi"
RUN dotnet build "net.webapi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "net.webapi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "net.webapi.dll"]
