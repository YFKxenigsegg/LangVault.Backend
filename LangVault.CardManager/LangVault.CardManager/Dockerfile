FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LangVault.CardManager/LangVault.CardManager/LangVault.CardManager.csproj", "LangVault.CardManager/LangVault.CardManager/"]
COPY ["LangVault.CardManager/LangVault.CardManager.Application/LangVault.CardManager.Application.csproj", "LangVault.CardManager/LangVault.CardManager.Application/"]
COPY ["LangVault.CardManager/LangVault.CardManager.Infrastructure/LangVault.CardManager.Infrastructure.csproj", "LangVault.CardManager/LangVault.CardManager.Infrastructure/"]
COPY ["LangVault.CardManager/LangVault.CardManager.Domain/LangVault.CardManager.Domain.csproj", "LangVault.CardManager/LangVault.CardManager.Domain/"]
COPY ["LangVault.CardManager/LangVault.CardManager.Infrastructure.Migrations/LangVault.CardManager.Infrastructure.Migrations.csproj", "LangVault.CardManager/LangVault.CardManager.Infrastructure.Migrations/"]
RUN dotnet restore "LangVault.CardManager/LangVault.CardManager/LangVault.CardManager.csproj"
COPY . .
WORKDIR "/src/LangVault.CardManager/LangVault.CardManager"
RUN dotnet build "LangVault.CardManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LangVault.CardManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LangVault.CardManager.dll"]