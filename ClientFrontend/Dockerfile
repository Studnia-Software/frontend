FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClientFrontend/ClientFrontend.csproj", "ClientFrontend/"]
COPY ["ApiClient/ApiClient.csproj", "ApiClient/"]
RUN dotnet restore "ClientFrontend/ClientFrontend.csproj"
COPY . .
WORKDIR "/src/ClientFrontend"
RUN dotnet build "ClientFrontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientFrontend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientFrontend.dll"]
