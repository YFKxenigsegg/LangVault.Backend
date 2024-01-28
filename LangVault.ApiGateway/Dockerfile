FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LangVault.ApiGateway/LangVault.ApiGateway.csproj", "LangVault.ApiGateway/"]
RUN dotnet restore "LangVault.ApiGateway/LangVault.ApiGateway.csproj"
COPY . .
WORKDIR "/src/LangVault.ApiGateway"
RUN dotnet build "LangVault.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LangVault.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LangVault.ApiGateway.dll"]